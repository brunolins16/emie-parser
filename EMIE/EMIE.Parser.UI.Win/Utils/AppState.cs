using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.UI.Win.Utils
{
    public static class AppState
    {
        public static Library.Entities.Entry[] SiteEntries { get; set; }
        public static Library.Entities.Entry[] ItemsToRemove { get; set; }
        public static Library.Entities.EntryDomain[] Domains { get; set; }

        public static void Clear()
        {
            ItemsToRemove = null;
            SiteEntries = null;
            Domains = null;
            GC.Collect();
        }
    }
}
