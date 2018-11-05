using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    //Representerar en lista med podcastavsnitt
    public class EpisodeList<T> : PodList<Episode>
    {
        //Tar emot en lista med SyndicationItems och skapar en EpisodeList
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

        //Skapar en array med ListViewItem
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
