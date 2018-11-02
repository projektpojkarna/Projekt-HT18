using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    public class PodCastList<T> : PodList<PodCast>
    {
        public PodCastList() : base() { }

        //Lägger till en pod om den inte redan finns i listan
        public override bool Add(PodCast pod)
        {
            if(!Contains(pod))
            {
                return base.Add(pod);
            }
            return false;
        }

        //Tar bort en pod;
        public void Remove(string url)
        {
            var podToRemove = Get(url);
            if(podToRemove != null)
                InnerList.Remove(podToRemove);
        }

        public PodCast Get(string url)
        {
            return InnerList.Single((p) => p.Url == url);
        }

        public override bool Contains(PodCast pod)
        {
            return InnerList.Any((p) => p.Url == pod.Url);
        }

    }
}
