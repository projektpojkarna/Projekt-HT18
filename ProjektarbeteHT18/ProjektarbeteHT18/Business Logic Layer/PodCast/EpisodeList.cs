using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.PodCast
{
    public class EpisodeList<T> : CustomList<PodCastEpisode>
    {

        public static EpisodeList<PodCastEpisode> FromSyndicationItems(IEnumerable<SyndicationItem> syndicationItems)
        {
            var episodeList = new EpisodeList<PodCastEpisode>();
            foreach (SyndicationItem item in syndicationItems)
            {
                episodeList.Add(PodCastEpisode.FromSyndicationItem(item));
            }
            return episodeList;
        }

        public EpisodeList() : base() { }


        public override ListViewItem[] ToListViewItems()
        {
            var lvItems = new List<ListViewItem>();
            var episodeNumber = InnerList.Count;

            var items = base.ToListViewItems();
            foreach(var item in items)
            {
                var displayEpisodeNumber = String.Format("#{0}",
                    episodeNumber.ToString());
                item.SubItems.Insert(0, new ListViewItem.ListViewSubItem(item, displayEpisodeNumber));
                lvItems.Add(item);
                episodeNumber--;
            }
            return lvItems.ToArray<ListViewItem>();
        }
    }
}
