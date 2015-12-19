using EMIE.Parser.Library.Entities;
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Utils
{
    public static class CSVHelper
    {
        public static IEnumerable<Entities.Entry> ReadEnterpriseDiscoveryCSV(string fileName)
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription { SeparatorChar = ',', FirstLineHasColumnNames = true, IgnoreUnknownColumns = true };
            return new CsvContext().Read<Entry>(fileName, inputFileDescription).Where(ent => !string.IsNullOrEmpty(ent.DocMode));
        }
    }
}
