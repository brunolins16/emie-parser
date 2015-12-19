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

        public void Fill(IEnumerable<Library.Entities.Entry> list)
        {
            dgwDomain.DataSource = (from entry in list
                                    group entry by entry.Url into pathGroup
                                    select pathGroup).ToList();
            dgwDomain.Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var selectedRows = (from r in dgwDomain.Rows.Cast<DataGridViewRow>()
                                select
                                new Library.Entities.Entry()
                                {
                                    Url = (r.DataBoundItem as IGrouping<Uri, Library.Entities.Entry>).First().Url,
                                    DocMode = r.Cells[0].Value.ToString()
                                });

            var handler = Events[EVENT_LOAD] as NextEventHandler;
            if (handler != null)
                handler(this, new NextEventArgs(selectedRows));
        }

        private void dgwDomain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgwDomain.Rows)
            {
                var entryGroup = row.DataBoundItem as IGrouping<Uri, Library.Entities.Entry>;

                var comboBoxCell = row.Cells[0] as DataGridViewComboBoxCell;
                comboBoxCell.DataSource = (from entry in entryGroup
                                           select entry.DocMode).ToList();
            }
        }
    }
}
