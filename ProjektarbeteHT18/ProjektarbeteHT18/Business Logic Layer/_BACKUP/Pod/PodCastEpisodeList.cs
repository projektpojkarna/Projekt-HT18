using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using ProjektarbeteHT18.Business_Logic_Layer.Interface;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer
{

    public class PodCastEpisodeList<T> : List<T> where T: PodCastEpisode
    {
        public static PodCastEpisodeList<PodCastEpisode> FromSyndicationItems(IEnumerable<SyndicationItem> syndicationItems)
        {
            var list = new PodCastEpisodeList<PodCastEpisode>();
            foreach (SyndicationItem item in syndicationItems)
            {
                list.Add(PodCastEpisode.FromSyndicationItem(item));
            }
            return list;
        }

        public ListViewItem[] ToListViewItems()
        {
            var dataToDisplay = new List<ListViewItem>();
            var episodeNumber = this.Count;

            foreach(var episode in this)
            {
                var displayEpisodeNumber = String.Format("#{0}",
                         episodeNumber.ToString());
                var lwi = episode.ToListViewItem();
                lwi.SubItems.Insert(0, new ListViewItem.ListViewSubItem(lwi, displayEpisodeNumber));
                dataToDisplay.Add(lwi);
                episodeNumber--;
            }
            return dataToDisplay.ToArray<ListViewItem>();
        }
    }
}
