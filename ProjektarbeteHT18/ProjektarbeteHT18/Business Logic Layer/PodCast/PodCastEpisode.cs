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
    public class PodCastEpisode : IPodCastEpisode, IListable
    {
        public static PodCastEpisode FromSyndicationItem(SyndicationItem syndicationItem)
        {
            string name = syndicationItem.Title.Text;
            string description = syndicationItem.Summary.Text;
            string episodeURL = "";
            var episode = new PodCastEpisode(description, episodeURL, name);
            return episode;
        }

        public ListViewItem ToListViewItem()
        {
            var dataToDisplay = new List<string> {Name};
            return new ListViewItem(dataToDisplay.ToArray());
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
