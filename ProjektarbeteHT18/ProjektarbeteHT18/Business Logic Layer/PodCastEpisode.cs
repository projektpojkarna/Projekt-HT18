using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class PodCastEpisode : IPodCastEpisode
    {
        public string Description { get; set; }
        public string FileURL { get; set ; }
        public string Name { get; set; }

        public PodCastEpisode(string description, string fileURL, string name)
        {
            Description = description;
            FileURL = fileURL;
            Name = name;
        }
    }
}
