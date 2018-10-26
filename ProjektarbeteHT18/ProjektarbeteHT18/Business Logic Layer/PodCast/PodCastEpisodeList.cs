using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;

namespace ProjektarbeteHT18.Business_Logic_Layer
{


    public class PodCastEpisodeList<T> : List<T> where T: IPodCastEpisode
    {
        public static PodCastEpisodeList<IPodCastEpisode> FromSyndicationItems(IEnumerable<SyndicationItem> syndicationItems)
        {
            var list = new PodCastEpisodeList<IPodCastEpisode>();
            foreach (SyndicationItem item in syndicationItems)
            {
                list.Add(PodCastEpisode.FromSyndicationItem(item));
            }
            return list;
        }
    }
}
