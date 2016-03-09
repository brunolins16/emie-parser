using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMIE.Parser.Library.Entities;

namespace EMIE.Parser.Library.Business
{
    public class SiteDiscovery
    {
        #region Public API

        public IEnumerable<Entities.Entry> Load(Entities.EntryFileInfo[] siteDiscoveryFiles, out IEnumerable<Entities.Entry> duplicateList)
        {
            //Carrega os itens
            IEnumerable<Entities.Entry> internalItens = LoadFiles(siteDiscoveryFiles);

            //Obtém as urls distintamente (Distinct)
            var discoveryEntries = (from entry in internalItens
                                    group entry by new
                                    {
                                        Host = entry.Url.Host,
                                        Port = entry.Url.Port,
                                        Scheme = entry.Url.Scheme,
                                        Path = entry.Url.LocalPath.Split(';')[0],
                                        DocMode = entry.DocMode
                                    } into path
                                    select new Library.Entities.Entry()
                                    {
                                        Url = new Uri(string.Format("{0}://{1}:{2}{3}", path.Key.Scheme, path.Key.Host, path.Key.Port, path.Key.Path)),
                                        DocMode = path.Key.DocMode,
                                        NumberOfVisits = path.Sum(p => p.NumberOfVisits)
                                    });

            //Checa os duplicados
            duplicateList = CheckDuplication(discoveryEntries);

            return discoveryEntries;
        }

        public IEnumerable<EntryDomain> ListDomains(Entry[] entries, string localHostName = "")
        {
            return from entry in entries
                   group entry by
                        new Uri(string.Format("{0}://{1}:{2}", entry.Url.Scheme, entry.Url.Host, entry.Url.Port))
                   into domain
                   select new Library.Entities.EntryDomain()
                   {
                       isLocal = (domain.Key.Host.Contains(localHostName) || (domain.Key.HostNameType == UriHostNameType.IPv4 && domain.Key.Host.StartsWith("10."))),
                       Name = domain.Key
                   };
        }

        public IEnumerable<Entities.Entry> Sanitize(Entities.Entry[] entries, Entities.EntryDomain[] domains = null, Entities.Entry[] itensToRemove = null)
        {
            if (domains != null)
            {
                //Filtra os domínios
                entries = (from entry in entries
                           join domain in domains
                               on new Uri(string.Format("{0}://{1}:{2}", entry.Url.Scheme, entry.Url.Host, entry.Url.Port)) equals domain.Name
                           select entry).ToArray();
            }

            if (itensToRemove != null)
            {
                //Filtra os itens removidos
                var removeList = itensToRemove.Select(e => string.Format("{0}-{1}", e.DocMode, e.Url.ToString()));
                entries = entries.Where(e => !removeList.Contains(string.Format("{0}-{1}", e.DocMode, e.Url.ToString()))).ToArray();
            }


            //Seleciona distintamente pelo host e modo de documento
            entries = entries.OrderBy(e => e.Url, new Entities.Comparer.UrlComparer()).Distinct(new Entities.Comparer.DocModeHostComparer()).ToArray();

            return entries;
        }

        #endregion

        private IEnumerable<Entry> CheckDuplication(IEnumerable<Entry> discoveryEntries)
        {
            var docModeQty = discoveryEntries.Distinct(new Library.Entities.Comparer.DocModeComparer()).Count();

            if (docModeQty > 1)
            {
                var duplicates = (from path in discoveryEntries.Distinct(new Library.Entities.Comparer.DocModePathComparer())
                                  group path by path.Url into duplicated
                                  where duplicated.Count() > 1
                                  select duplicated).SelectMany(g => g);

                foreach (var item in duplicates)
                    yield return item;
            }
        }

        private IEnumerable<Entities.Entry> LoadFiles(Entities.EntryFileInfo[] siteDiscoveryFiles)
        {
            var fileTypes = new string[] { ".xls", ".xlsx", ".pdf", ".doc", ".docx", ".ppt", ".pptx", ".csv", ".jpg", ".png", ".bmp", ".tif", ".gif", ".xsl", ".wsdl", ".xml" };
            var discoveryEntries = new ConcurrentBag<Entities.Entry>();
            //Carrega todos os arquivos
            Parallel.ForEach(siteDiscoveryFiles, item =>
            {
                IEnumerable<Library.Entities.Entry> entries;

                if (item.Type == Entities.EntryFileType.CSV)
                    entries = Utils.CSVHelper.ReadEnterpriseDiscoveryCSV(item.FileName);
                else
                    entries = Utils.XmlHelper.ReadEnterpriseDiscoveryXml(item.FileName);

                foreach (var entry in entries)
                    discoveryEntries.Add(entry);
            });

            return discoveryEntries.AsEnumerable().Where(e => !fileTypes.Contains(System.IO.Path.GetExtension(e.Url.LocalPath)));
        }
    }
}
