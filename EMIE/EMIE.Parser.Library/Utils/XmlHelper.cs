using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EMIE.Parser.Library.Utils
{
    public static class XmlHelper
    {
        public static void MakeEMIESiteList(IEnumerable<Entities.Entry> entries, string fileName)
        {
            var siteEntries = entries.Select(entry => new XElement("site",
                                new XAttribute("url", string.Format("{0}:{1}{2}", entry.Url.Host, entry.Url.Port, entry.Url.LocalPath.Split(';')[0])),
                                new XElement("compat-mode", string.Format("IE{0}", entry.DocMode)),
                                new XElement("open-in", "IE11")));

            XElement siteList = new XElement("site-list", new XAttribute("version", 0), siteEntries);

            //Salva o arquivo em disco
            siteList.Save(fileName);
        }


        public static void MakeEMIESiteListV1(IEnumerable<Entities.Entry> entries, string fileName)
        {
            var group = from entry in entries
                        group entry by new { entry.Url.Host, entry.Url.Port } into domain
                        select domain;
            List<XElement> siteEntries = new List<XElement>();

            foreach (var item in group)
            {
                XElement domain = null;

                if (item.Any(e => string.IsNullOrEmpty(e.Url.LocalPath) || e.Url.LocalPath.Equals("/")))
                {
                    var children = item.Where(e => !string.IsNullOrEmpty(e.Url.LocalPath) && !e.Url.LocalPath.Equals("/")).Select(e => new XElement("path", e.Url.LocalPath.Split(';')[0], new XAttribute("docMode", e.DocMode)));
                    domain = item.Where(e => string.IsNullOrEmpty(e.Url.LocalPath) || e.Url.LocalPath.Equals("/")).Select(e => new XElement("domain",
                                    string.Format("{0}:{1}", e.Url.Host, e.Url.Port),
                                    new XAttribute("docMode", e.DocMode), children)).SingleOrDefault();
                }
                else
                    domain  = item.Select(e => new XElement("domain", 
                        string.Format("{0}:{1}{2}", e.Url.Host, e.Url.Port, e.Url.LocalPath.Split(';')[0]), 
                        new XAttribute("docMode", e.DocMode))).FirstOrDefault();

                siteEntries.Add(domain);
                
            }

            XElement siteList = new XElement("rules", new XAttribute("version", 0), new XElement("docMode", siteEntries));

            //Salva o arquivo em disco
            siteList.Save(fileName);
        }

        public static IEnumerable<Entities.Entry> ReadEnterpriseDiscoveryXml(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var discoverListxml = XElement.Load(fileName);

            return discoverListxml.Elements("IEURLInfo").Where(e => e.Elements("DocMode").Any()).Select(e => new Entities.Entry()
            {
                Url = new Uri(e.Element("URL").Value),
                NumberOfVisits = Convert.ToInt32(e.Element("NumberOfVisits").Value),
                DocMode = e.Element("DocMode").Value,
                DocModeReason = e.Element("DocModeReason").Value,
                BrowserStateReason = e.Element("BrowserStateReason").Value
            });
        }
    }
}
