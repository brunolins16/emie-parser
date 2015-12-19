using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Entities.Comparer
{
    public class DocModeComparer : IEqualityComparer<Entities.Entry>
    {
        public bool Equals(Entry x, Entry y)
        {
            return x.DocMode.Equals(y.DocMode);
        }

        public int GetHashCode(Entry obj)
        {
            return obj.DocMode.GetHashCode();
        }
    }
}
