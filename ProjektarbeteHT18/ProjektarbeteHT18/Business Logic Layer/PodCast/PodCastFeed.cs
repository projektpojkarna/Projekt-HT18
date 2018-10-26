﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class PodCastFeed : IPodCastFeed
    {
        public static PodCastFeed FromSyndicationFeed(SyndicationFeed feed)
        {
            var episodes = new PodCastEpisodeList<IPodCastEpisode>();
            string feedTitle = feed.Title.Text;
            var feedURL = feed.Links[0].Uri.ToString();
            var lastUpdated = feed.LastUpdatedTime;

            foreach (SyndicationItem item in feed.Items)
            {  
                string name = item.Title.Text;
                string description = item.Summary.Text;
                string episodeURL = "";
                var episode = new PodCastEpisode(description, episodeURL, name);
                episodes.Add(episode);
            }
            return new PodCastFeed(feedURL, feedTitle, episodes, lastUpdated);
        }

        public PodCastFeed(string url, String name, PodCastEpisodeList<IPodCastEpisode> episodes, DateTimeOffset lastUpdated)
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
        public PodCastEpisodeList<IPodCastEpisode> Episodes { get; set; }

    }
}
