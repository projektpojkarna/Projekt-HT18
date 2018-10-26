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

        public delegate void PodCastRefreshHandler();
        public event PodCastRefreshHandler OnPodAdded;

        public PodRefresher()
        {

        }
    }
}
