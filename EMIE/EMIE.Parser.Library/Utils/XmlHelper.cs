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
                                new XAttribute("url", new Uri(string.Format("{0}://{1}:{2}{3}", entry.Url.Scheme, entry.Url.Host, entry.Url.Port, entry.Url.LocalPath.Split(';')[0]))),
                                new XElement("compat-mode", string.Format("IE{0}", entry.DocMode)),
                                new XElement("open-in", "IE11")));

            XElement siteList = new XElement("site-list", new XAttribute("version", 0), siteEntries);

            //Salva o arquivo em disco
            siteList.Save(fileName);
        }
    }
}
