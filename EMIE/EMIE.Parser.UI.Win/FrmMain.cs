using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMIE.Parser.UI.Win
{
    public partial class FrmMain : Form
    {
        IEnumerable<Library.Entities.Entry> list;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void emieFileUploadControl1_MoveNext(object sender, UserControls.NextEventArgs e)
        {
            emieFileUploadControl1.Visible = false;

            list = e.Entries;

            domainListControl1.Fill(list);
            domainListControl1.Visible = true;
        }

        private void domainListControl1_MoveNext(object sender, UserControls.NextEventArgs e)
        {

            domainListControl1.Visible = false;

            //Prepara a lista
            var duplicateList = PreprocessList(e.Entries);

            duplicateListControl1.Fill(duplicateList);
            duplicateListControl1.Visible = true;
        }

        private void duplicateListControl1_MoveNext(object sender, UserControls.NextEventArgs e)
        {
            foreach (var item in e.Entries)
                list.Single(entry => entry.Url.Equals(item.Url)).DocMode = item.DocMode;


            var domains = from entry in list
                          group entry by new { entry.Url.Host, entry.Url.Port } into domain
                          select domain;

            var entryList = new ConcurrentBag<Library.Entities.Entry>();
            Parallel.ForEach(domains, d =>
            {
                var paths = (from entry in d
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

                var docModeQty = paths.Distinct(new Library.Entities.Comparer.DocModeComparer()).Count();

                if (docModeQty == 1)
                {
                    var root = new Library.Entities.Entry();

                    if (paths.Any(p => string.IsNullOrEmpty(p.Url.LocalPath) || p.Url.LocalPath.Equals("/")))
                        root = paths.FirstOrDefault(en => string.IsNullOrEmpty(en.Url.LocalPath) || en.Url.LocalPath.Equals("/"));
                    else
                    {
                        root = paths.First();
                        root.Url = new Uri(string.Format("{0}://{1}:{2}",root.Url.Scheme, root.Url.Host, root.Url.Port));
                    }                      
                    
                    entryList.Add(root);
                }
                else
                {
                    foreach (var item in paths.Distinct(new Library.Entities.Comparer.PathComparer()))
                        entryList.Add(item);
                }
            });
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Site List v1 (Win7/8.1)|*.xml|Site List v2 (Win10)|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                    Library.Utils.XmlHelper.MakeEMIESiteListV1(entryList, saveFileDialog.FileName);
                else
                    Library.Utils.XmlHelper.MakeEMIESiteList(entryList, saveFileDialog.FileName);

                MessageBox.Show("Arquivo salvo com sucesso!", "Geraçào de arquivo Site List",MessageBoxButtons.OK);
                StartOver();
                entryList = null;
            }
        }

        private void StartOver()
        {
            emieFileUploadControl1.Visible = true;
            emieFileUploadControl1.Clear();
            duplicateListControl1.Visible = false;
            list = null;
        }

        private IEnumerable<Library.Entities.Entry> PreprocessList(IEnumerable<Library.Entities.Entry> entries)
        {
            var domains = from entry in (from ent in list
                                         join domain in entries
                                             on new Uri(string.Format("{0}://{1}:{2}", ent.Url.Scheme, ent.Url.Host, ent.Url.Port)) equals domain.Url
                                         select ent)
                          group entry by new { entry.Url.Host, entry.Url.Port } into domain
                          select domain;

            var entryList = new ConcurrentBag<Library.Entities.Entry>();
            var duplicateList = new ConcurrentBag<Library.Entities.Entry>();
            Parallel.ForEach(domains, d =>
            {
                var paths = (from entry in d
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

                var docModeQty = paths.Distinct(new Library.Entities.Comparer.DocModeComparer()).Count();

                if (docModeQty == 1)
                    entryList.Add(paths.First());
                else
                {
                    var duplicates = (from path in paths.Distinct(new Library.Entities.Comparer.DocModePathComparer())
                                     group path by path.Url into duplicated
                                     where duplicated.Count() > 1
                                     select duplicated).SelectMany(g => g);

                    foreach (var item in duplicates)
                        duplicateList.Add(item);

                    foreach (var item in paths.Distinct(new Library.Entities.Comparer.PathComparer()))
                        entryList.Add(item);
                }
            });

            list = entryList.ToList();
            return duplicateList;
        }

        private void emieFileUploadControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
