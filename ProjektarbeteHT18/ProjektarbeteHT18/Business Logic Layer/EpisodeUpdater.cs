using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class EpisodeUpdater
    {
        Timer t;
        int ElapsedMintues;

        public EpisodeUpdater(ElapsedEventHandler Updater)
        {
            t = new Timer();
            t.Interval = 300000;
            t.Elapsed += new ElapsedEventHandler(CheckPodUpdates);
            ElapsedMintues = 0;
            t.Start();
        }

        //Lägger till det senaste avsnittet i listan
        public async void CheckPodUpdates(object source, ElapsedEventArgs eArgs)
        {
            ElapsedMinutes += 5;
            var needsUpdate = PodCastFeedList.Where((p) => (ElapsedMinutes % p.UpdateInterval == 0)).ToList();
            foreach (PodCastFeed p in needsUpdate)
            {
                await UpdateEpisodeList(p);
            }
        }
    }
}
