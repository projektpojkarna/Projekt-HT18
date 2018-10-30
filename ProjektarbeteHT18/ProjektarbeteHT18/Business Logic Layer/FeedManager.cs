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

        public delegate void PodCastAddedHandler();
        public event PodCastAddedHandler OnPodAdded;

        private Timer t;
        int ElapsedMinutes;

        Serializer<PodCastFeedList<PodCastFeed>> Serializer;

        public FeedManager()
        {
            t = new Timer();
            t.Interval = 300000;
            t.Elapsed += new ElapsedEventHandler(CheckPodUpdates);
            t.Start();

            Deserialize();

        }

        public void Serialize()
        {
            if(PodCastFeedList != null)
            {
                Serializer.Serialize(PodCastFeedList);
            }
        }

        public async void Deserialize()
        {
            var jsonFile = "jsonData.json";
            Serializer = new Serializer<PodCastFeedList<PodCastFeed>>(jsonFile);
            if (File.Exists(jsonFile))
            {
                PodCastFeedList = Serializer.Deserialize();
                foreach (var p in PodCastFeedList)
                {
                    await UpdateEpisodeList(p);
                }
            }
            else
            {
                PodCastFeedList = new PodCastFeedList<PodCastFeed>();
            }
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

                    //Avfyra event
                    if (OnPodAdded != null)
                    {
                        FirePodAdded();
                    }
                });
        }

        private async Task UpdateEpisodeList(PodCastFeed feed)
        {
            var updatedFeed = await ReadRSSAsync(feed.Url);
            feed.Episodes = PodCastEpisodeList<PodCastEpisode>.FromSyndicationItems(updatedFeed.Items);

            if (OnPodAdded != null)
            {
                FirePodAdded();
            }
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