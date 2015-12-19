using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Entities.Comparer
{
    public class PathComparer : IEqualityComparer<Entities.Entry>
    {
        public bool Equals(Entry x, Entry y)
        {
            return x.Url.Equals(y.Url);
        }

        public int GetHashCode(Entry obj)
        {
            return obj.Url.GetHashCode();
        }
    }
}
