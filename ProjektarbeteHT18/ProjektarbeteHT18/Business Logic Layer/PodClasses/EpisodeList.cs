using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    public class EpisodeList<T> : PodList<Episode>
    {

        public static EpisodeList<Episode> FromSyndicationItems(IEnumerable<SyndicationItem> syndicationItems)
        {
            var episodeList = new EpisodeList<Episode>();
            foreach (SyndicationItem item in syndicationItems)
            {
                episodeList.Add(Episode.FromSyndicationItem(item));
            }
            return episodeList;
        }

        public EpisodeList() : base() { }

        public override ListViewItem[] ToListViewItems()
        {
            var dataToDisplay = new List<ListViewItem>();
            var episodeNumber = Count;

            foreach (var episode in InnerList)
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
