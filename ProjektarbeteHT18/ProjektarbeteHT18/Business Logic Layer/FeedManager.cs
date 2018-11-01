using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Timers;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using ProjektarbeteHT18.Business_Logic_Layer.Exceptions;
using ProjektarbeteHT18.Business_Logic_Layer.Categories;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class FeedManager
    {
        public PodCastList<PodCast> PodCastList { get; set; }
        public CategoryList<Category> CategoryList { get; set; }

        public delegate void PodCastAddedHandler();
        public event PodCastAddedHandler OnPodUpdate;

        public delegate void ErrorHandler(string msg);
        public event ErrorHandler OnError;

        [JsonIgnore] public ExceptionHandler ExceptionHandler { get; set; }

        private System.Timers.Timer t;
        int ElapsedMinutes;

        Serializer<FeedManager> Serializer;

        public static FeedManager FromJsonOrDefault(string jsonFile)
        {
            var serializer = new Serializer<FeedManager>(jsonFile);

            if (File.Exists(jsonFile))
            {
                var fm = serializer.Deserialize();
                foreach(var p in fm.PodCastList.GetAll())
                {
                    fm.UpdatePodCast(p);
                }
                return fm;
            }
            else
            {
                return new FeedManager();
            }
        }


        private FeedManager()
        {
            CategoryList = new CategoryList<Category>();
            PodCastList = new PodCastList<PodCast>();

            t = new System.Timers.Timer();
            t.Interval = 30000;
            t.Elapsed += new ElapsedEventHandler(RefreshPods);
            t.Start();

            Serializer = new Serializer<FeedManager>("jsonData.json");
            ExceptionHandler = new ExceptionHandler();
        }

        public void Serialize()
        {
            Serializer.Serialize(this);
        }


        //Tar bort en kategori; kollar först att kategorin inte används
        public void RemoveCategory(string category)
        {
            bool isUsed = PodCastList.GetAll().Any((p) => p.Category == category);
            if (isUsed)
            {
                OnError("Kategorin används av en eller flera podcasts.");
            }
            else
            {
                CategoryList.Remove(category);
            }
        }

        //Lägger till en ny podcast
        public async Task AddNewPod(string url, string category, int updateInterval)
        {
            //TODO: Kolla först om poden finns!

           //Läs in RSS-flöde, skapa podcast-objekt och lägg till i listan
            await ReadRSSAsync(url).ContinueWith((t) => {
                if(t.Exception == null && t.Result != null)
                {
                    var feed = t.Result;
                    var pod = PodCast.FromSyndicationFeed(feed, url);
                    pod.Category = category;
                    pod.UpdateInterval = updateInterval;
                    PodCastList.Add(pod);

                    FirePodUpdated();
                }
            });    
        }

        public async Task RemovePod(string url)
        {
            await Task.Run(() =>
            {
                PodCastList.Remove(url);
                FirePodUpdated();
            });
        }

        //Gör om metoden; ta bort poden och lägg till igen?
        public async Task UpdateExistingPodCast(int index, string newUrl, int newInterval, string newCategory)
        {
            var pod = PodCastList.Get(index);
            pod.UpdateInterval = newInterval;
            pod.Category = newCategory;
            if (newUrl != pod.Url)
            {
                pod.Url = newUrl;
                await CheckForPodUpdates(pod);
            }
            else
            {
                FirePodUpdated();
            }
        }

        private async Task UpdatePodCast(PodCast pod)
        {
            var updatedFeed = await ReadRSSAsync(pod.Url);
            UpdatePodCast(pod, updatedFeed);
        }

        //Uppdaterar en podcast
        private void UpdatePodCast(PodCast pod, SyndicationFeed updatedFeed)
        {
            pod.Name = updatedFeed.Title.Text;
            pod.LastUpdated = updatedFeed.LastUpdatedTime;
            pod.Episodes = PodCastEpisodeList<PodCastEpisode>.FromSyndicationItems(updatedFeed.Items);
            FirePodUpdated();
        }

        //Kollar om en podcast har den senaste uppdateringen
        private async Task CheckForPodUpdates(PodCast pod)
        {
            var updatedFeed = await ReadRSSAsync(pod.Url);
            if (pod.LastUpdated < updatedFeed.LastUpdatedTime)
            {
                UpdatePodCast(pod, updatedFeed);
            }
        }

        //Anropas av timern; kollar vilka pods vars uppdateringsintervall stämmer överrens med timern
        public async void RefreshPods(object source, ElapsedEventArgs eArgs)
        {
            ElapsedMinutes +=5;
            var podsToUpdate = PodCastList.GetAll().Where((p) => (ElapsedMinutes % p.UpdateInterval == 0)).ToList();
            foreach (PodCast p in podsToUpdate)
            {
                await CheckForPodUpdates(p);
            }
        }

        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            var result = await Task.Run(() =>
            {
                var settings = new XmlReaderSettings()
                {
                    Async = true,
                    DtdProcessing = DtdProcessing.Parse,
                    MaxCharactersFromEntities = 1024
                };
                SyndicationFeed f = null;
                try
                {
                    using (XmlReader reader = XmlReader.Create(url, settings))
                    {
                        f = SyndicationFeed.Load(reader);
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler.HandleException(e);
                }
                return f;
            });
            return result;
        }

        //Metod för att hantera händelseanrop
        private void FirePodUpdated()
        {
            if (OnPodUpdate != null)
            {
                OnPodUpdate();
            }
        }
    }
}