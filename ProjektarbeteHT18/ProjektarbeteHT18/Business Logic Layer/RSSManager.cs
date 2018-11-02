using System;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using ProjektarbeteHT18.Business_Logic_Layer.Exceptions;
using ProjektarbeteHT18.Business_Logic_Layer.Pod;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class RSSManager
    {
        ExceptionHandler ExceptionHandler;

        public RSSManager(ExceptionHandler handler)
        {
            ExceptionHandler = handler;
        }

        //Uppdaterar en podcast om poden har en uppdatering
        public async Task<bool> UpdatePodIfNeeded(PodCast p)
        {
            var updatedFeed = await ReadRSSAsync(p.Url);
            bool updated = false;
            if(updatedFeed.LastUpdatedTime > p.LastUpdated)
            {
                PerformPodUpdate(p, updatedFeed);
                updated = true;
            }
            return updated;
        }

        //Uppdaterar en podcast
        public async Task<PodCast> UpdatePodCast(PodCast p) {
            var updatedFeed = await ReadRSSAsync(p.Url);
            return PerformPodUpdate(p, updatedFeed);
        }

        //Läser in en RSS-feed och skapar ett podcast-objekt
        public async Task<PodCast> GetPodCast(string url)
        {
            return PodCast.FromSyndicationFeed(await ReadRSSAsync(url), url);
        }

        //Genomför en uppdatering av en podcast med en uppdaterad feed
        private PodCast PerformPodUpdate(PodCast p, SyndicationFeed updatedFeed)
        {
            p.Name = updatedFeed.Title.Text;
            p.LastUpdated = updatedFeed.LastUpdatedTime;
            p.Episodes = EpisodeList<Episode>.FromSyndicationItems(updatedFeed.Items);
            return p;
        }

        //Läser RSS-feed och returnerar ett SyndicationFeed-objekt
        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            //Läser url och returnerar ett SyndicationFeed-objekt
            return await Task.Run(() =>
            {
                var settings = new XmlReaderSettings()
                {
                    Async = true,
                    DtdProcessing = DtdProcessing.Parse,
                    MaxCharactersFromEntities = 1024
                };
                SyndicationFeed f = null;
                //Läs in RSS
                try
                {
                    using (XmlReader reader = XmlReader.Create(url, settings))
                    {
                        f = SyndicationFeed.Load(reader);
                        reader.Close();
                    }
                }
                //Om exception uppstått, hantera med exceptionhandler
                catch (Exception e)
                {
                    ExceptionHandler.HandleException(e);
                }
                return f; //Returnera feed till Task
            });
        }

    }
}
