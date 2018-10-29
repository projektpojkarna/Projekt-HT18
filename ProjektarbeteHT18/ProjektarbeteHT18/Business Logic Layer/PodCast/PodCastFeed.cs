using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class PodCastFeed : IPodCastFeed, IListable
    {
        public static PodCastFeed FromSyndicationFeed(SyndicationFeed feed)
        {
            var episodes = new PodCastEpisodeList<PodCastEpisode>();
            string feedTitle = feed.Title.Text;
            var feedURL = feed.Links.Single((p) => p.MediaType == "application/rss+xml").Uri.ToString();
            var lastUpdated = feed.LastUpdatedTime;

            foreach (SyndicationItem item in feed.Items)
            {
                episodes.Add(PodCastEpisode.FromSyndicationItem(item));
            }
            return new PodCastFeed(feedURL, feedTitle, episodes, lastUpdated);
        }

        public ListViewItem ToListViewItem()
        {
            var dataToDisplay = new List<string> {
                Episodes.Count.ToString(),
                Name,
                UpdateInterval.ToString(),
                Category };
            return new ListViewItem(dataToDisplay.ToArray());
        }

        public PodCastFeed(string url, String name, PodCastEpisodeList<PodCastEpisode> episodes, DateTimeOffset lastUpdated)
        {
            Url = url;
            Name = name;
            Episodes = episodes;
            Category = "";
            LastUpdated = lastUpdated;
        }

        public string Url { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int UpdateInterval { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public PodCastEpisodeList<PodCastEpisode> Episodes { get; set; }

    }
}
