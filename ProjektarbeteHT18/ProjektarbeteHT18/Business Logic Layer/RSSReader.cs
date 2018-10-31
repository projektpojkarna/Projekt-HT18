using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjektarbeteHT18.Business_Logic_Layer
{
    public class RSSReader
    {
        private async Task<SyndicationFeed> ReadRSSAsync(string url)
        {
            var syndicationFeed = await Task.Run(() => {
                var settings = new XmlReaderSettings() { Async = true, DtdProcessing = DtdProcessing.Parse, MaxCharactersFromEntities = 1024 };
                using (XmlReader reader = XmlReader.Create(url, settings))
                {
                    var f = SyndicationFeed.Load(reader);
                    reader.Close();
                    return f;

                }
            });
            return syndicationFeed;
        }

    }
}
