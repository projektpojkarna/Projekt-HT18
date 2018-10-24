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
    class Buisiness
    {
        public PodCastFeedList<PodCastFeed> PodCastFeedList { get; set;}

        public Buisiness()
        {
            PodCastFeedList = new PodCastFeedList<PodCastFeed>();
        }

        //Laddar in en podcast feed
        public async Task<PodCastFeed> ReadRSSAsync(string url)
        {
            var episodes = new PodCastEpisodeList<IPodcastEpisode>();
            using (XmlReader reader = XmlReader.Create(url, new XmlReaderSettings() { Async = true }))
            {
                var feed = SyndicationFeed.Load(reader);
                reader.Close();
                string feedTitle = feed.Title.Text ;
                
                foreach (SyndicationItem item in feed.Items)
                {
                    String name = item.Title.Text;
                    String description = item.Summary.Text;
                    String podUrl = "";
                    var episode = new PodCastEpisode(description, podUrl, name);
                    episodes.Add(episode);
                }
                var pod = new PodCastFeed(url, feedTitle, episodes);
                await Task.Delay(1000); // <--- FULING!
                PodCastFeedList.Add(pod);
                return pod;
            }


        }
    }
}
