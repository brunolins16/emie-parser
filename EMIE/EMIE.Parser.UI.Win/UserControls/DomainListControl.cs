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
    public partial class DomainListControl : BaseUserControl
    {
        public DomainListControl()
        {
            InitializeComponent();
        }

        public void Fill()
        {
            var library = new Library.Business.SiteDiscovery();
            dgwDomain.AutoGenerateColumns = false;
            dgwDomain.DataSource = library.ListDomains(Utils.AppState.SiteEntries, "bradesco.com.br").ToArray();
            dgwDomain.Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Utils.AppState.Domains = (from r in dgwDomain.Rows.Cast<DataGridViewRow>()
                                select r.DataBoundItem as Library.Entities.EntryDomain).Where(ent => ent.isLocal).ToArray();

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(Utils.Steps.DuplicationClean));

            dgwDomain.DataSource = null;
        }

        private void DomainListControl_Load(object sender, EventArgs e)
        {
            Fill();
        }
    }
}
