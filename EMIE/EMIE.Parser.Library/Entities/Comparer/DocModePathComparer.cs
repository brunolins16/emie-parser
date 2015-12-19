using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Entities.Comparer
{
    public class DocModePathComparer : IEqualityComparer<Entities.Entry>
    {
        public bool Equals(Entry x, Entry y)
        {
            return string.Format("{0}{1}",x.DocMode,x.Url).Equals(string.Format("{0}{1}", y.DocMode, y.Url));
        }

        public int GetHashCode(Entry obj)
        {
            return string.Format("{0}{1}", obj.DocMode, obj.Url).GetHashCode();
        }
    }
}
