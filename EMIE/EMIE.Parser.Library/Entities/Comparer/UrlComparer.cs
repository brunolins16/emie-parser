using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Entities.Comparer
{
    public class UrlComparer : IComparer<System.Uri>
    {
        public int Compare(Uri x, Uri y)
        {
           return string.CompareOrdinal(x.ToString(), y.ToString());
        }
    }
}
