using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.Library.Entities
{
    public class Entry
    {
        [CsvColumn(Name = "URL", FieldIndex = 1)]
        public Uri Url{get;set;}

        [CsvColumn(Name = "NumberOfVisits", FieldIndex = 2)]
        public int NumberOfVisits{get;set;}

        [CsvColumn(Name = "SystemIEVer", FieldIndex = 3)]
        public string SystemIEVer {get;set;}

        [CsvColumn(Name = "DocMode", FieldIndex = 4)]
        public string DocMode {get;set;}

        [CsvColumn(Name = "DocModeReason", FieldIndex = 5)]
        public string DocModeReason{get;set;}

        [CsvColumn(Name = "OSName", FieldIndex = 6)]
        public string OSName{get;set;}

        [CsvColumn(Name = "BrowserStateReason", FieldIndex = 11)]
        public string BrowserStateReason{get;set;} //11


        public bool Selected { get; set; }

    }

    public enum IEVersion
    {
        None = 0,
        IE5 = 5,
        IE8 = 8,
        IE9 = 9,
        IE10 = 10,
        IE11 = 11
    }
}
