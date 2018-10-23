using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    interface IPodCastFeed
    {
        string Url { get; set; }
        string Name { get; set; }
        ICategory Category { get; set; }
        int UpdateInterval { get; set; }
        PodCastEpisodeList<IPodcastEpisode> Episodes { get; set; }
    }
}
