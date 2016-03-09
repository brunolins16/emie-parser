using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMIE.Parser.Library.Entities;

namespace EMIE.Parser.UI.Win.UserControls
{
    public partial class FileUploadItem : UserControl
    {
        public delegate void ItemRemovedEventHandler(object sender, EventArgs e);
        protected static readonly object EVENT_LOAD = new object();

        public event ItemRemovedEventHandler ItemRemoved
        {
            add
            {
                Events.AddHandler(EVENT_LOAD, value);
            }
            remove
            {
                Events.RemoveHandler(EVENT_LOAD, value);
            }
        }

        public EntryFileType SourceType { get; private set; }
        public string FileName { get { return lblName.Text; } }

        public FileUploadItem()
        {
            InitializeComponent();
        }

        public FileUploadItem(string fileName, EntryFileType sourceType) : this()
        {
            lblName.Text = fileName;
            this.SourceType = sourceType;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var handler = Events[EVENT_LOAD] as ItemRemovedEventHandler;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
