using System;
using System.Collections.Generic;
using System.IO;
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
                var root = item.Where(e => string.IsNullOrEmpty(e.Url.LocalPath) || e.Url.LocalPath.Equals("/")).SingleOrDefault();
                var hostExcluded = !item.Any(e => string.IsNullOrEmpty(e.Url.LocalPath) || e.Url.LocalPath.Equals("/")); 

                var children = item
                    .Where(e => !string.IsNullOrEmpty(e.Url.LocalPath) && !e.Url.LocalPath.Equals("/"))
                    .Select(e => new XElement("path", e.Url.LocalPath.Split(';')[0], new XAttribute("docMode", e.DocMode)));


                XElement domain = new XElement("domain",
                                                string.Format("{0}:{1}", item.Key.Host, item.Key.Port),
                                                new XAttribute("exclude", hostExcluded),
                                                new XAttribute("docMode", (root != null ? root.DocMode : "edge")),
                                                children);


                //Bug on subdmonain itens
                //if (item.Any(e => string.IsNullOrEmpty(e.Url.LocalPath) || e.Url.LocalPath.Equals("/")))
                //{
                //    var children = item.Where(e => !string.IsNullOrEmpty(e.Url.LocalPath) && !e.Url.LocalPath.Equals("/")).Select(e => new XElement("path", e.Url.LocalPath.Split(';')[0], new XAttribute("docMode", e.DocMode)));
                //    domain = item.Where(e => string.IsNullOrEmpty(e.Url.LocalPath) || e.Url.LocalPath.Equals("/")).Select(e => new XElement("domain",
                //                    string.Format("{0}:{1}", e.Url.Host, e.Url.Port),
                //                    new XAttribute("docMode", e.DocMode), children)).SingleOrDefault();
                //}
                //else
                //    domain = item.Select(e => new XElement("domain",
                //       string.Format("{0}:{1}{2}", e.Url.Host, e.Url.Port, e.Url.LocalPath.Split(';')[0]),
                //       new XAttribute("docMode", e.DocMode))).FirstOrDefault();

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

            //Prepara o xml
            PrepareXMLFile(fileName);

            var discoverListxml = XElement.Load(fileName);

            return discoverListxml.Elements("IEURLInfo").Where(e => e.Elements("DocMode").Any()).Select(e =>
            {
                Uri url = null;
                Uri.TryCreate(e.Element("URL").Value, UriKind.RelativeOrAbsolute, out url);

                return new Entities.Entry()
                {
                    Url = url,
                    NumberOfVisits = Convert.ToInt32(e.Element("NumberOfVisits").Value),
                    DocMode = e.Element("DocMode").Value,
                    DocModeReason = e.Element("DocModeReason").Value,
                    BrowserStateReason = e.Element("BrowserStateReason").Value
                };
            }).Where(e => e.Url != null);
        }

        private static void PrepareXMLFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            File.WriteAllText(fileName, string.Join(string.Empty, lines));
        }
    }
}
