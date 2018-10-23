using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    interface IPodcastEpisode
    {
        string Description { get; set; }
        string FileURL { get; set; }
        string Name { get; set; }
    }
}
