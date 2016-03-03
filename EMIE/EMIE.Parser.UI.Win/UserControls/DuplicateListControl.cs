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
    public partial class DuplicateListControl : BaseUserControl
    {
        public DuplicateListControl()
        {
            InitializeComponent();
        }

        public void Fill(Library.Entities.Entry[] list)
        {
            var library = new Library.Business.SiteDiscovery();
            dgwDomain.DataSource = (from entry in library.Sanitize(list.ToArray(), Utils.AppState.Domains)
                                    group entry by entry.Url into pathGroup
                                    select pathGroup).ToList();
            dgwDomain.Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var selectedItems = dgwDomain.Rows.Cast<DataGridViewRow>().Select(r => string.Format("{0}-{1}", r.Cells[0].Value.ToString(), (r.DataBoundItem as IGrouping<Uri, Library.Entities.Entry>).First().Url.ToString()));
            Utils.AppState.ItemsToRemove = Utils.AppState.ItemsToRemove.Where(entry => !selectedItems.Contains(string.Format("{0}-{1}", entry.DocMode, entry.Url.ToString()))).ToArray();

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(Utils.Steps.Download));

            dgwDomain.DataSource = null;
            dgwDomain.Refresh();
        }

        private void dgwDomain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgwDomain.Rows)
            {
                var entryGroup = row.DataBoundItem as IGrouping<Uri, Library.Entities.Entry>;

                var comboBoxCell = row.Cells[0] as DataGridViewComboBoxCell;
                var items = (from entry in entryGroup
                             orderby int.Parse(entry.DocMode) ascending
                             select entry.DocMode).ToList();
                comboBoxCell.DataSource = items;
                comboBoxCell.Value = items.First();
            }
        }

        private void DuplicateListControl_Load(object sender, EventArgs e)
        {
            Fill(Utils.AppState.ItemsToRemove);
        }
    }
}
