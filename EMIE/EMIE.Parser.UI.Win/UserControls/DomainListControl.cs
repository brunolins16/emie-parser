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

        public void Fill(IEnumerable<Library.Entities.Entry> list)
        {

            dgwDomain.AutoGenerateColumns = false;
            dgwDomain.DataSource = (from entry in list
                                    group entry by new Uri(string.Format("{0}://{1}:{2}", entry.Url.Scheme, entry.Url.Host, entry.Url.Port)) into domain
                                    select new Library.Entities.Entry()
                                    {
                                        Selected = (domain.Key.Host.Contains("bradesco.com.br") || (domain.Key.HostNameType == UriHostNameType.IPv4 && domain.Key.Host.StartsWith("10."))),
                                        Url = domain.Key
                                    }).ToList();
            dgwDomain.Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var selectedRows = (from r in dgwDomain.Rows.Cast<DataGridViewRow>()
                                select r.DataBoundItem as Library.Entities.Entry).Where(ent => ent.Selected);

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(selectedRows));

            dgwDomain.DataSource = null;
            dgwDomain.Refresh();
        }

        private void DomainListControl_Load(object sender, EventArgs e)
        { }
    }
}
