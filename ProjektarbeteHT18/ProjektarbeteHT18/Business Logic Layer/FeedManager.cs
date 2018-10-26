using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System.ServiceModel.Syndication;
using System.Xml;


namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class FeedManager
    {
        public PodCastFeedList<PodCastFeed> PodCastFeedList { get; set; }
        public delegate void PodCastAddedHandler();
        public event PodCastAddedHandler OnPodAdded;


        public FeedManager()
        {
            PodCastFeedList = new PodCastFeedList<PodCastFeed>();
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

        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            var episodes = new PodCastEpisodeList<IPodCastEpisode>();
            var syndicationFeed = await Task.Run(() => {
                using (XmlReader reader = XmlReader.Create(url, new XmlReaderSettings() { Async = true }))
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
