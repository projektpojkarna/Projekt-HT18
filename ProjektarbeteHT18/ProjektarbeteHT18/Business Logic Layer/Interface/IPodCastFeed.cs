using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public interface IPodCastFeed
    {
        string Url { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        int UpdateInterval { get; set; }
        PodCastEpisodeList<PodCastEpisode> Episodes { get; set; }

    }
}
