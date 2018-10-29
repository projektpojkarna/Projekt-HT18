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
        private Stopwatch sw;
        int ElapsedMinutes;


        public FeedManager()
        {
            PodCastFeedList = new PodCastFeedList<PodCastFeed>();

            sw = new Stopwatch();
            DateTime dt = new DateTime();
            t = new Timer();
            t.Interval = 30000;
            t.Elapsed += new ElapsedEventHandler(RefreshPod);
            t.Start();
        }

        public void Serialize()
        {
            var fileName = "podurls.json";
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var urls = PodCastFeedList.GetURLs();
                serializer.Serialize(jsonWriter, urls);
            }
        }

        //Lägger till en ny podcast
        public async Task AddNewPod(string url, string category, int updateInterval)
        {
            //TODO: Kolla först om poden finns!

                //Läs in RSS-flöde, skapa podcast-objekt och lägg till i listan
                await ReadRSSAsync(url).ContinueWith((feed) => {
                    
                    var pod = PodCastFeed.FromSyndicationFeed(feed.Result);
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

        //Lägger till det senaste avsnittet i listan
        public async void RefreshPod(object source, ElapsedEventArgs eArgs)
        {
            ElapsedMinutes +=5;

            var needsUpdate = PodCastFeedList.Where((p) => (ElapsedMinutes % p.UpdateInterval == 0)).ToList();

            foreach(PodCastFeed p in needsUpdate)
            {
                var updatedFeed = await ReadRSSAsync(p.Url);

                p.Episodes.Clear();
                p.Episodes = PodCastEpisodeList<PodCastEpisode>.FromSyndicationItems(updatedFeed.Items);
                
                //var freshPod = PodCastFeed.FromSyndicationFeed(updatedFeed);
                //PodCastFeedList.Remove(p);
                //PodCastFeedList.Add(freshPod);
            }

            if(OnPodAdded != null)
            {
                FirePodAdded();
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