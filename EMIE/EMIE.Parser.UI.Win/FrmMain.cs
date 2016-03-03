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
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CreateContent(Utils.Steps.FileUpload);
        }

        public void CreateContent(Utils.Steps step)
        {
            if (pnlContent.Controls.Count > 0)
            {
                var currentControl = pnlContent.Controls[0] as UserControls.BaseUserControl;

                if (currentControl != null)
                    currentControl.Dispose();

                //Remove todos os controles de conteudo
                pnlContent.Controls.Clear();
            }

            //Cria um istancia do controle
            var userControl = Utils.UserControlFactory.Instantiate(step);
            userControl.MoveNext += UserControl_MoveNext;

            //Adiciona o controle na tela
            pnlContent.Controls.Add(userControl);
        }

        private void UserControl_MoveNext(object sender, UserControls.NextEventArgs e)
        {
            if (e.Step != Utils.Steps.Download)
                //Cria o novo controle
                CreateContent(e.Step);
            else
                ExportFile();
        }

        private void ExportFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Site List v1 (Win7/8.1)|*.xml|Site List v2 (Win10)|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Obtém a lista de sites para exportação
                var library = new Library.Business.SiteDiscovery();
                var entriesToExport = library.Sanitize(Utils.AppState.SiteEntries, Utils.AppState.Domains, Utils.AppState.ItemsToRemove);

                if (saveFileDialog.FilterIndex == 1)
                    Library.Utils.XmlHelper.MakeEMIESiteListV1(entriesToExport, saveFileDialog.FileName);
                else
                    Library.Utils.XmlHelper.MakeEMIESiteList(entriesToExport, saveFileDialog.FileName);

                //Limpas as váriaveis
                Utils.AppState.Clear();           

                //Apresenta o controle inicial
                CreateContent(Utils.Steps.FileUpload);

                MessageBox.Show("Arquivo salvo com sucesso!", "Geraçào de arquivo Site List", MessageBoxButtons.OK);
            }

        }
    }
}
