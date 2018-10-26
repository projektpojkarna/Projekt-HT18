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
                //Läs in RSS-flöde, skapa podcast-objekt och lägg till i listan
                await ReadRSSAsync(url).ContinueWith((p) => {
                    var pod = p.Result;
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

        private async Task<PodCastFeed> ReadRSSAsync(string url)
        {
            var episodes = new PodCastEpisodeList<IPodCastEpisode>();
            var podCastFeed = await Task.Run(() => {
                using (XmlReader reader = XmlReader.Create(url, new XmlReaderSettings() { Async = true }))
                {
                    var syndicationFeed = SyndicationFeed.Load(reader);
                    reader.Close();
                    return PodCastFeed.FromSyndicationFeed(syndicationFeed);
                }
            }); //.ContinueWith((f) => AddPodToList(f.Result))
            return podCastFeed;
        }

        /*
        private void AddPodToList(PodCastFeed feed)
        {
            PodCastFeedList.Add(feed);
            if(OnPodAdded != null)
            {
                FirePodAdded();
            }
        }*/

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
