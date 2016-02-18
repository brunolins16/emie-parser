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
    public enum SourceType
    {
           CSV = 1,
           XML = 2
    }

    public partial class EMIEFileUploadControl : BaseUserControl
    {
        private SourceType sourceType = SourceType.CSV;
        
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
                    pnlFileList.Controls.Add(new FileUploadItem(selectedFile, (SourceType)opdDiscoveryFile.FilterIndex));
                
            }
        }

        private void EMIEFileUploadControl_Load(object sender, EventArgs e)
        {}

        private void btnNext_Click(object sender, EventArgs e)
        {
            var discoveryEntries = new ConcurrentBag<Library.Entities.Entry>();
            Parallel.ForEach(pnlFileList.Controls.Cast<FileUploadItem>(), item => {
                IEnumerable<Library.Entities.Entry> entries;

                if (item.SourceType == SourceType.CSV)
                    entries = Library.Utils.CSVHelper.ReadEnterpriseDiscoveryCSV(item.FileName);
                else
                    entries = Library.Utils.XmlHelper.ReadEnterpriseDiscoveryXml(item.FileName);

                foreach (var entry in entries)
                    discoveryEntries.Add(entry);
            });           

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(discoveryEntries));
        }

        private void rdbType_CheckedChanged(object sender, EventArgs e)
        {
            sourceType = (SourceType)Convert.ToInt32((sender as Control).Tag);
        }
    }
}
