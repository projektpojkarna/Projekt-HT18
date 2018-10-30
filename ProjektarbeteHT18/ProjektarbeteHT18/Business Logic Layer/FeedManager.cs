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

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class FeedManager
    {
        public PodCastFeedList<PodCastFeed> PodCastFeedList { get; set; }
        public CategoryList CategoryList { get; set; }

        public delegate void PodCastAddedHandler();
        public event PodCastAddedHandler OnPodAdded;

        private Timer t;
        int ElapsedMinutes;

        EpisodeUpdater EpisodeUpdater;

        Serializer<FeedManager> Serializer;

        public static FeedManager FromJsonOrDefault(string jsonFile)
        {
            var serializer = new Serializer<FeedManager>(jsonFile);

            if (File.Exists(jsonFile))
            {
                var fm = serializer.Deserialize();
                foreach(var p in fm.PodCastFeedList)
                {
                    fm.UpdateEpisodeList(p);
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
            PodCastFeedList = new PodCastFeedList<PodCastFeed>();

            EpisodeUpdater = new EpisodeUpdater(new ElapsedEventHandler(CheckPodUpdates));

            t = new Timer();
            t.Interval = 300000;
            t.Elapsed += new ElapsedEventHandler(CheckPodUpdates);
            t.Start();

            Serializer = new Serializer<FeedManager>("jsonData.json");

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
                    
                    var pod = PodCastFeed.FromSyndicationFeed(feed.Result, url);
                    pod.Category = category;
                    pod.UpdateInterval = updateInterval;
                    PodCastFeedList.Add(pod);

                    FirePodAdded();
                });
        }

        public async Task RemovePod(string url)
        {
            await Task.Run(() =>
            {
                PodCastFeedList.RemovePodByUrl(url);
                //Avfyra event för uppdatering av listan3
                FirePodAdded();
            });
        }

        //Lägger till det senaste avsnittet i listan
        public async void CheckPodUpdates(object source, ElapsedEventArgs eArgs)
        {
            ElapsedMinutes +=5;
            var needsUpdate = PodCastFeedList.Where((p) => (ElapsedMinutes % p.UpdateInterval == 0)).ToList();
            foreach(PodCastFeed p in needsUpdate)
            {
                await UpdateEpisodeList(p);
            }
        }

        private async Task UpdateEpisodeList(PodCastFeed feed)
        {
            var updatedFeed = await ReadRSSAsync(feed.Url);
            feed.Episodes = PodCastEpisodeList<PodCastEpisode>.FromSyndicationItems(updatedFeed.Items);
            FirePodAdded();
        }

        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            var syndicationFeed = await Task.Run(() => {
            var settings = new XmlReaderSettings() { Async = true, DtdProcessing = DtdProcessing.Parse, MaxCharactersFromEntities = 1024};
            using (XmlReader reader = XmlReader.Create(url, settings))
                {
                    var f = SyndicationFeed.Load(reader);
                    reader.Close();
                    return f;
                  
                }
            });
            return syndicationFeed;
        }

        public void RemoveCategory(string category)
        {
            bool isUsed = PodCastFeedList.Any((p) => p.Category == category );
            if(isUsed)
            {
                throw new Exception();
            }
            CategoryList.Remove(category);
        }

        //Metod för att hantera händelseanrop
        private void FirePodAdded()
        {
            if (OnPodAdded != null)
            {
                OnPodAdded();
            }
        }
    }
}