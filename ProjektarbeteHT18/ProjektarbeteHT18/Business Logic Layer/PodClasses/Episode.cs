using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    //Representerar ett podcastavnistt
    public class Episode : IEpisode, IListable
    {
        public string Description { get; set; }
        public string FileURL { get; set; }
        public string Name { get; set; }

        public Episode(string description, string fileURL, string name)
        {
            Description = description;
            FileURL = fileURL;
            Name = name;
        }

        //Tar emot en SyndicationFeed och returnerar en Episode
        public static Episode FromSyndicationItem(SyndicationItem syndicationItem)
        {
            string name = syndicationItem.Title.Text;
            string description = syndicationItem.Summary != null ? syndicationItem.Summary.Text : "";
            string episodeURL = syndicationItem.Links[0].ToString();
            return new Episode(description, episodeURL, name);
        }

        //Returnerar en representationa av avsnittet som ett ListViewItem
        public ListViewItem ToListViewItem()
        {
            var dataToDisplay = new List<string> {Name};
            return new ListViewItem(dataToDisplay.ToArray());
        }


    }
}
