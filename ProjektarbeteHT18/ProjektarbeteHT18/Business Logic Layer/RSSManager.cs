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

        //Uppdaterar en podcast
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

        public async Task<PodCast> UpdatePodCast(PodCast p) {
            var updatedFeed = await ReadRSSAsync(p.Url);
            return PerformPodUpdate(p, updatedFeed);
        }

        public async Task<PodCast> GetPodCast(string url)
        {
            return PodCast.FromSyndicationFeed(await ReadRSSAsync(url), url);
        }

        private PodCast PerformPodUpdate(PodCast p, SyndicationFeed updatedFeed)
        {
            p.Name = updatedFeed.Title.Text;
            p.LastUpdated = updatedFeed.LastUpdatedTime;
            p.Episodes = EpisodeList<Episode>.FromSyndicationItems(updatedFeed.Items);
            return p;
        }

        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            var result = await Task.Run(() =>
            {
                var settings = new XmlReaderSettings()
                {
                    Async = true,
                    DtdProcessing = DtdProcessing.Parse,
                    MaxCharactersFromEntities = 1024
                };
                SyndicationFeed f = null;
                try
                {
                    using (XmlReader reader = XmlReader.Create(url, settings))
                    {
                        f = SyndicationFeed.Load(reader);
                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler.HandleException(e);
                }
                return f;
            });
            return result;
        }

    }
}
