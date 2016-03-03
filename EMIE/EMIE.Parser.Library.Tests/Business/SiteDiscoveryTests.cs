using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMIE.Parser.Library.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Business.Tests
{
    [TestClass()]
    public class SiteDiscoveryTests
    {
        [TestMethod()]
        public void LoadOneFileWithoutDuplication()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> duplicates;
            var entries = library.Load(new Entities.EntryFileInfo[] { new Entities.EntryFileInfo() { FileName = @"Files/Sample.xml",
                Type = Entities.EntryFileType.XML } }, out duplicates);


            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsTrue(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 2, "O número de itens é diferente de 2");

            Assert.IsFalse(duplicates.Any(), "Existem duplicados");
        }

        [TestMethod()]
        public void LoadTwoFileWithoutDuplication()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> duplicates;
            var entries = library.Load(new Entities.EntryFileInfo[] {
                new Entities.EntryFileInfo() { FileName = @"Files/Sample.xml", Type = Entities.EntryFileType.XML },
                new Entities.EntryFileInfo() { FileName = @"Files/Sample.xml", Type = Entities.EntryFileType.XML }
            }, out duplicates);

            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsTrue(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 2, "O número de itens é diferente de 2");

            Assert.IsFalse(duplicates.Any(), "Existem duplicados");
        }

        [TestMethod()]
        public void LoadOneFileWithDuplication()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> duplicates;
            var entries = library.Load(new Entities.EntryFileInfo[] { new Entities.EntryFileInfo() { FileName = @"Files/sampleDuplication.xml",
                Type = Entities.EntryFileType.XML } }, out duplicates);


            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsTrue(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 3, "O número de itens é diferente de 2");

            Assert.IsNotNull(duplicates, "Existem duplicados");
            Assert.IsTrue(duplicates.Count() == 2, "O número de itens duplicados é diferente de 2");
        }

        [TestMethod()]
        public void ListDomains()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> entries = new List<Entities.Entry>(){
                new Entities.Entry() { Url = new Uri("http://www.contoso.com") },
                new Entities.Entry() {  Url = new Uri("http://www.contoso2.com")  },
            };

            var domains = library.ListDomains(entries.ToArray());

            Assert.IsNotNull(domains, "Objeto está nulo");
            Assert.IsTrue(domains.Any(), "Nenhum item encontrado");
            Assert.IsTrue(domains.Count() == 2, "O número de itens é diferente de 2");
        }

        [TestMethod()]
        public void ListDomainsWithHostname()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> entries = new List<Entities.Entry>(){
                new Entities.Entry() { Url = new Uri("http://www.contoso.com") },
                new Entities.Entry() {  Url = new Uri("http://www.contoso2.com")  },
            };

            var domains = library.ListDomains(entries.ToArray(), "www.contoso.com");

            Assert.IsNotNull(domains, "Objeto está nulo");
            Assert.IsTrue(domains.Any(), "Nenhum item encontrado");
            Assert.IsTrue(domains.Any(d => d.isLocal), "Nenhum item, como endereço local, encontrado");
            Assert.IsTrue(domains.Any(d => d.isLocal), "Itens, como endereço externo, não encontrado");
            Assert.IsTrue(domains.Count() == 2, "O número de itens é diferente de 1");
        }

        [TestMethod()]
        public void SanitizeAllDomainsTest()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> entries = new List<Entities.Entry>(){
                new Entities.Entry() { Url = new Uri("http://www.contoso.com") },
                new Entities.Entry() {  Url = new Uri("http://www.contoso2.com")  },
            };

            var domains = library.ListDomains(entries.ToArray());

            entries = library.Sanitize(entries.ToArray(), domains.ToArray());

            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsTrue(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 2, "O número de itens é diferente de 2");
        }

        [TestMethod()]
        public void SanitizeRemoveAllTest()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> entries = new List<Entities.Entry>(){
                new Entities.Entry() { Url = new Uri("http://www.contoso.com"), DocMode = "9" },
                new Entities.Entry() {  Url = new Uri("http://www.contoso2.com") , DocMode = "10" },
            };

            var domains = library.ListDomains(entries.ToArray());

            entries = library.Sanitize(entries.ToArray(), itensToRemove: entries.ToArray());

            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsFalse(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 0, "O número de itens é diferente de 0");
        }

        [TestMethod()]
        public void SanitizeRemoveOneTest()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> entries = new List<Entities.Entry>(){
                new Entities.Entry() { Url = new Uri("http://www.contoso.com"), DocMode = "9" },
                new Entities.Entry() { Url = new Uri("http://www.contoso.com"), DocMode = "11" },
                new Entities.Entry() {  Url = new Uri("http://www.contoso2.com") , DocMode = "10" },
            };

            var domains = library.ListDomains(entries.ToArray());

            entries = library.Sanitize(entries.ToArray(), itensToRemove: new Entities.Entry[] { entries.First() });

            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsTrue(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 2, "O número de itens é diferente de 0");
        }

        [TestMethod()]
        public void SanitizeFiltredDomainsTest()
        {
            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Entities.Entry> entries = new List<Entities.Entry>(){
                new Entities.Entry() { Url = new Uri("http://www.contoso.com") },
                new Entities.Entry() {  Url = new Uri("http://www.contoso2.com")  },
            };

            var domains = library.ListDomains(entries.ToArray());

            entries = library.Sanitize(entries.ToArray(), new Entities.EntryDomain[] { domains.First() });

            Assert.IsNotNull(entries, "Objeto está nulo");
            Assert.IsTrue(entries.Any(), "Nenhum item encontrado");
            Assert.IsTrue(entries.Count() == 1, "O número de itens é diferente de 1");
        }
    }
}