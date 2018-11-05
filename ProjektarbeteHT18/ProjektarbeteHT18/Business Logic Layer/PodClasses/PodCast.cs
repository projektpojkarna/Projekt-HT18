using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    //Representerar en PodCast-feed
    public class PodCast : IPodCast, IListable
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int UpdateInterval { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        //Vid deserialisering av podcasten vill vi läsa in de senaste avsnitten
        [JsonIgnore] public EpisodeList<Episode> Episodes { get; set; }

        //Tar emot en SyndicationFeed och returnerar en PodCast
        public static PodCast FromSyndicationFeed(SyndicationFeed feed, string url)
        {
            var episodes = new EpisodeList<Episode>();
            var feedTitle = feed.Title.Text;
            //Alla RSS-flöden lagrar inte URL i länksamlingen,
            //vi lade till URL som parameter i metoden istället.
            //var feedURL = feed.Links.SingleOrDefault((p) => p.MediaType == "application/rss+xml").Uri.ToString();
            var feedURL = url;
            var lastUpdated = feed.LastUpdatedTime;

            foreach (SyndicationItem item in feed.Items)
            {
                episodes.Add(Episode.FromSyndicationItem(item));
            }
            return new PodCast(feedURL, feedTitle, episodes, lastUpdated);
        }

        [JsonConstructor]public PodCast(string url, String name, EpisodeList<Episode> episodes, DateTimeOffset lastUpdated)
        {
            Url = url;
            Name = name;
            if(episodes != null)
            {
                Episodes = episodes;
            }
            else
            {
                Episodes = new EpisodeList<Episode>();
            }
            Category = "";
            LastUpdated = lastUpdated;
        }

        //Returnerar en representation av en PodCast som ett ListViewItem
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
