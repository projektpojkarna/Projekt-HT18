using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class Timer
    {
        System.Timers.Timer t;
        int ElapsedMintues;

        public Timer(ElapsedEventHandler Updater)
        {
            t = new System.Timers.Timer();
            t.Interval = 300000; //Avfyrar ElapsedEventHandler var 5:e minut
            t.Elapsed += new ElapsedEventHandler(Updater);
            ElapsedMintues = 0;
            t.Start();
        }
    }
}
