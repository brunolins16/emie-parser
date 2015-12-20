using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMIE.Parser.UI.Win.UserControls
{
    enum SourceType
    {
           CSV = 0,
           XML = 1
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
            txtFile.Text = string.Empty;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //Exibe a caixa de seleção
            if (opdDiscoveryFile.ShowDialog() == DialogResult.OK)
            {
                var selectedFile = opdDiscoveryFile.FileName;
                txtFile.Text = selectedFile;                                 
            }
        }

        private void EMIEFileUploadControl_Load(object sender, EventArgs e)
        { }

        private void btnNext_Click(object sender, EventArgs e)
        {
            IEnumerable<Library.Entities.Entry> discoveryEntries = new List<Library.Entities.Entry>();

            if (sourceType == SourceType.CSV)
                discoveryEntries = Library.Utils.CSVHelper.ReadEnterpriseDiscoveryCSV(txtFile.Text);
            else
                discoveryEntries = Library.Utils.XmlHelper.ReadEnterpriseDiscoveryXml(txtFile.Text);

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
