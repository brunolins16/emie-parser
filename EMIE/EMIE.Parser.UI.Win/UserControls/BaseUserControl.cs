using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMIE.Parser.UI.Win.UserControls
{
    public class NextEventArgs : EventArgs {

        public NextEventArgs(Utils.Steps nextStep)
        {
            this.Step = nextStep;
        }

        public Utils.Steps Step { get; set; }
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
