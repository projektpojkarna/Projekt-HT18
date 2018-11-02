using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    public class Episode : IEpisode, IListable
    {
        public static Episode FromSyndicationItem(SyndicationItem syndicationItem)
        {
            string name = syndicationItem.Title.Text;
            string description = syndicationItem.Summary != null ? syndicationItem.Summary.Text : "";
            string episodeURL = syndicationItem.Links[0].ToString();
            var episode = new Episode(description, episodeURL, name);
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

        public Episode(string description, string fileURL, string name)
        {
            Description = description;
            FileURL = fileURL;
            Name = name;
        }
    }
}
