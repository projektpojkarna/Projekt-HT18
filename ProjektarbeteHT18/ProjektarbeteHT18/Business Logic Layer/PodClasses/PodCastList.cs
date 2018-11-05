using System.Collections.Generic;
using System.Linq;

namespace ProjektarbeteHT18.Business_Logic_Layer.Pod
{
    //Representerar en lista med podcastavsnitt
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
        //Hämtar en pod
        public PodCast Get(string url)
        {
            return InnerList.SingleOrDefault((p) => p.Url == url);
        }

        //Kollar om en pod med samma url finns i listan
        public override bool Contains(PodCast pod)
        {
            return InnerList.Any((p) => p.Url == pod.Url);
        }

        //Returnerar en lista med alla pods i en viss kategori
        public List<PodCast> GetPodsByCategory(string category)
        {
            return InnerList.Where((p) => p.Category == category).ToList();
        }

    }
}
