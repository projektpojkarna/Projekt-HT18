using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    public class PodCast : IPodCastFeed, IListable
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int UpdateInterval { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        [JsonIgnore] public PodCastEpisodeList<PodCastEpisode> Episodes { get; set; }

        public static PodCast FromSyndicationFeed(SyndicationFeed feed, string url)
        {
            var episodes = new PodCastEpisodeList<PodCastEpisode>();
            var feedTitle = feed.Title.Text;
            //Alla RSS-flöden lagrar inte URL i länksamlingen,
            //vi lade till URL som parameter i metoden istället.
            //var feedURL = feed.Links.SingleOrDefault((p) => p.MediaType == "application/rss+xml").Uri.ToString();
            var feedURL = url;
            var lastUpdated = feed.LastUpdatedTime;

            foreach (SyndicationItem item in feed.Items)
            {
                episodes.Add(PodCastEpisode.FromSyndicationItem(item));
            }
            return new PodCast(feedURL, feedTitle, episodes, lastUpdated);
        }

        [JsonConstructor]private PodCast(string url, String name, PodCastEpisodeList<PodCastEpisode> episodes, DateTimeOffset lastUpdated)
        {
            Url = url;
            Name = name;
            if(episodes != null)
            {
                Episodes = episodes;
            }
            else
            {
                Episodes = new PodCastEpisodeList<PodCastEpisode>();
            }
            Category = "";
            LastUpdated = lastUpdated;
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
    }
}
