using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMIE.Parser.UI.Win.UserControls
{
    public class NextEventArgs : EventArgs {

        public NextEventArgs(IEnumerable<Library.Entities.Entry>  entries)
        {
            this.Entries = entries;
        }

        public IEnumerable<Library.Entities.Entry> Entries { get; set; }
    }

    public class BaseUserControl : UserControl
    {
        public delegate void NextEventHandler(object sender, NextEventArgs e);
        protected static readonly object EVENT_LOAD = new object();

        public event NextEventHandler MoveNext
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
    }
}
