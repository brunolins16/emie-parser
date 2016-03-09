using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;

namespace EMIE.Parser.UI.Win.UserControls
{
    public partial class EMIEFileUploadControl : BaseUserControl
    {
        public EMIEFileUploadControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            pnlFileList.Controls.Clear();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            opdDiscoveryFile.Filter = "CSV Report Exported|*.csv|XML Report Exported|*.xml";

            //Exibe a caixa de seleção
            if (opdDiscoveryFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var selectedFile in opdDiscoveryFile.FileNames)
                {
                    var item = new FileUploadItem(selectedFile, (Library.Entities.EntryFileType)opdDiscoveryFile.FilterIndex);
                    item.Width = pnlFileList.Width - 40;
                    item.ItemRemoved += Item_ItemRemoved;
                    pnlFileList.Controls.Add(item);
                }
            }
        }

        private void Item_ItemRemoved(object sender, EventArgs e)
        {
            pnlFileList.Controls.Remove(sender as Control);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var files = pnlFileList.Controls.Cast<FileUploadItem>().Select(item => (new Library.Entities.EntryFileInfo()
            {
                FileName = item.FileName,
                Type = item.SourceType
            })).ToArray();

            var library = new Library.Business.SiteDiscovery();

            IEnumerable<Library.Entities.Entry> duplicatedItems = null;
            Utils.AppState.SiteEntries = library.Load(files, out duplicatedItems).ToArray();
            Utils.AppState.ItemsToRemove = duplicatedItems.ToArray();

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(Utils.Steps.DomainFiltering));
        }
    }
}
