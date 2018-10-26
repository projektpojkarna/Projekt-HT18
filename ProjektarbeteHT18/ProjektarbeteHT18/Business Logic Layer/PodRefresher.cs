using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class PodRefresher
    {
        private Timer t;
        private Stopwatch sw;
        //delegate PodCastFeed PodRefreshHandler();
        //event PodCastFeed OnTimerTick;

        public delegate PodCastFeed PodCastRefreshHandler();
        public event PodCastRefreshHandler OnPodAdded;

        public PodRefresher()
        {
            t = new Timer();
            sw = new Stopwatch();

            t.Interval = 300000;
            t.Start();
            sw.Start();
        }

        private void RefreshPods(object o, EventArgs eventArgs)
        {
            long elapsedTime = sw.ElapsedMilliseconds;

            foreach(PodCastFeed p in FeedList)
            {
                if (elapsedTime % p.UpdateInterval==0)
                {
                    
                }

            }

        }
    }
}
