using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Entities.Comparer
{
    public class DocModeHostComparer : IEqualityComparer<Entities.Entry>
    {
        public bool Equals(Entry x, Entry y)
        {
            return string.Format("{3}{0}://{1}:{2}",x.Url.Scheme, x.Url.Host, x.Url.Port,x.DocMode).Equals(string.Format("{3}{0}://{1}:{2}", y.Url.Scheme, y.Url.Host, y.Url.Port, y.DocMode));
        }

        public int GetHashCode(Entry obj)
        {
            return string.Format("{3}{0}://{1}:{2}", obj.Url.Scheme, obj.Url.Host, obj.Url.Port, obj.DocMode).GetHashCode();
        }
    }
}
