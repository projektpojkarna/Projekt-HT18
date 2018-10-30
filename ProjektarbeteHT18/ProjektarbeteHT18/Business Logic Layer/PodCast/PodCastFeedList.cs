using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class PodCastFeedList<T> : List<T> where T : IPodCastFeed
    {
        public IPodCastFeed GetPodByURL(string url)
        {
            try
            {
                return this.Single((p) => p.Url == url);
            } catch(Exception e)
            {

            }
            return null;

        }

        public void RemovePodByUrl(string url)
        {
            Remove(this.Single((p) => p.Url == url));
        }

        public void AddFeed(string url)
        {
            bool feedExists = ContainsURL(url);
            if(feedExists)
            {
                throw new Exception(); //TODO: Lägg till egen exception här!
            }
            else
            {
                //Todo: Lägg till i listan
            }

            
        }

        private bool ContainsURL(string url)
        {
            return this.Any(feed => feed.Url == url);
        }
    }
}
