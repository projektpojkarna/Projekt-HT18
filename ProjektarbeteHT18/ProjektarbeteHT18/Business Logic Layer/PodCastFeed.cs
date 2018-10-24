using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    class PodCastFeed : IPodCastFeed
    {

        public PodCastFeed(string url, String name, PodCastEpisodeList<IPodcastEpisode> episodes)
        {
           
            Url = url;
            Name = name;
            Episodes = episodes;
            lock (sync)
            {
             Id = ++globalCount;
            }
        }
        private static object sync = new object();
        public static int globalCount;

        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public ICategory Category { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdateInterval { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public PodCastEpisodeList<IPodcastEpisode> Episodes { get; set; }

    }
}
