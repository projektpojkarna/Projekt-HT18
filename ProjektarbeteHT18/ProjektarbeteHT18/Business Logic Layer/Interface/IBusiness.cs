using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer.Interface
{
    interface IBusiness
    {
       
        PodCastFeedList<IPodCastFeed> ListOfPods { get; set; }
        CategoryList ListOfCategories { get; set; }

        Task<IPodCastFeed> ReadRSSAsync(string url); //Läser in RSS och skapar PodCast-objekt

        void AddPodCast(IPodCastFeed pod);
        void RemovePodCast(IPodCastFeed pod);
        void UpdatePodCast(IPodCastFeed pod);



    }
}
