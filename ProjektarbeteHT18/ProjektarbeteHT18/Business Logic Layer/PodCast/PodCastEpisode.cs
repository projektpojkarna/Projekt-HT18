using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class PodCastEpisode : IPodCastEpisode
    {
        public static PodCastEpisode FromSyndicationItem(SyndicationItem syndicationItem)
        {
            string name = syndicationItem.Title.Text;
            string description = syndicationItem.Summary.Text;
            string episodeURL = "";
            var episode = new PodCastEpisode(description, episodeURL, name);
            return episode;
        }

        public string Description { get; set; }
        public string FileURL { get; set ; }
        public string Name { get; set; }

        public PodCastEpisode(string description, string fileURL, string name)
        {
            Description = description;
            FileURL = fileURL;
            Name = name;
        }
    }
}
