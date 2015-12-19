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
    public partial class EMIEFileUploadControl : BaseUserControl
    {
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
            var discoveryEntries = Library.Utils.CSVHelper.ReadEnterpriseDiscoveryCSV(txtFile.Text);

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(discoveryEntries));
        }
    }
}
