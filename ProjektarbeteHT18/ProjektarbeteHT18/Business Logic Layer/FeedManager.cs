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

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class FeedManager
    {
        public PodCastList<PodCast> PodCastFeedList { get; set; }
        public CategoryList CategoryList { get; set; }

        public delegate void PodCastAddedHandler();
        public event PodCastAddedHandler OnPodUpdate;

        public delegate void ErrorHandler(string msg);
        public event ErrorHandler OnError;

        [JsonIgnore] public ExceptionHandler ExceptionHandler { get; set; }

        private Timer t;
        int ElapsedMinutes;

        Serializer<FeedManager> Serializer;

        public static FeedManager FromJsonOrDefault(string jsonFile)
        {
            var serializer = new Serializer<FeedManager>(jsonFile);

            if (File.Exists(jsonFile))
            {
                var fm = serializer.Deserialize();
                foreach(var p in fm.PodCastFeedList)
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
            CategoryList = new CategoryList();
            PodCastFeedList = new PodCastList<PodCast>();

            t = new Timer();
            t.Interval = 300000;
            t.Elapsed += new ElapsedEventHandler(CheckPodUpdates);
            t.Start();

            Serializer = new Serializer<FeedManager>("jsonData.json");
            ExceptionHandler = new ExceptionHandler();

        }

        public void Serialize()
        {
            Serializer.Serialize(this);
        }

        //Lägger till en ny podcast
        public async Task AddNewPod(string url, string category, int updateInterval)
        {
            //TODO: Kolla först om poden finns!

           //Läs in RSS-flöde, skapa podcast-objekt och lägg till i listan
            await ReadRSSAsync(url).ContinueWith((feed) => {
                if(feed.Exception == null)
                {
                    var pod = PodCast.FromSyndicationFeed(feed.Result, url);
                    pod.Category = category;
                    pod.UpdateInterval = updateInterval;
                    PodCastFeedList.Add(pod);

                    FirePodUpdated();
                }
            });    
        }

        private async Task AddNewPod(PodCast feed)
        {
            await Task.Run(() => {
                PodCastFeedList.Add(feed);
            });
        }

        public async Task RemovePod(string url)
        {
            await Task.Run(() =>
            {
                PodCastFeedList.RemovePodByUrl(url);
                //Avfyra event för uppdatering av listan
                FirePodUpdated();
            });
        }


        //Lägger till det senaste avsnittet i listan
        public async void CheckPodUpdates(object source, ElapsedEventArgs eArgs)
        {
            ElapsedMinutes +=5;
            var needsUpdate = PodCastFeedList.Where((p) => (ElapsedMinutes % p.UpdateInterval == 0)).ToList();
            foreach(PodCast p in needsUpdate)
            {
                await UpdatePodCast(p);
            }
        }

        private async Task UpdatePodCast(PodCast pod)
        {
            var updatedFeed = await ReadRSSAsync(pod.Url);
            pod.Name = updatedFeed.Title.Text;
            pod.Episodes = PodCastEpisodeList<PodCastEpisode>.FromSyndicationItems(updatedFeed.Items);
            FirePodUpdated();
        }

        public async Task UpdatePodCast(int index, string newUrl, int newInterval, string newCategory)
        {
            var pod = PodCastFeedList[index];
            pod.UpdateInterval = newInterval;
            pod.Category = newCategory;
            if (newUrl != pod.Url)
            {
                pod.Url = newUrl;
                await UpdatePodCast(pod);
            }
            else
            {
                FirePodUpdated();
            }
        }

        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            var syndicationFeed = await Task.Run(() =>
            {
                var settings = new XmlReaderSettings()
                {
                    Async = true,
                    DtdProcessing = DtdProcessing.Parse,
                    MaxCharactersFromEntities = 1024
                };
                var f = new SyndicationFeed();
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
            return syndicationFeed;
        }

        public void RemoveCategory(string category)
        {
            bool isUsed = PodCastFeedList.Any((p) => p.Category == category );
            if(isUsed)
            {
                OnError("Kategorin används av en eller flera podcasts.");
            } else
            {
                CategoryList.Remove(category);
            }
           
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