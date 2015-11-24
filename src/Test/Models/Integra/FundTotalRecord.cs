using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Integra.Converters;

namespace Test.Models.Integra
{
    [FixedLengthFile]
    public class FundTotalRecord
    {
        [FixedLengthField(1, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string JournalReference { get; set; } //blank

        [FixedLengthField(2, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string SourceCode { get; set; } //blank

        [FixedLengthField(3, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string Year { get; set; } 

        [FixedLengthField(4, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string JournalPeriod { get; set; } 

        [FixedLengthField(5, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string JournalType { get; set; } //blank

        [FixedLengthField(6, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ", Converter = typeof(DateTimeConverter))]
        public DateTime JournalDate { get; set; } 

        [FixedLengthField(7, 16, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string GeneralLedgerCode { get; set; }

        [FixedLengthField(8, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string GeneralLedgerCodeBlank { get; set; }

        [FixedLengthField(9 ,3, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string FundIndicator { get; set; }

        [FixedLengthField(10, 38, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string ServiceNameDescription { get; set; }

        [FixedLengthField(10, 30, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string References { get; set; }

        [FixedLengthField(11, 12, PaddingChar = ' ', Padding = Padding.Left, Converter = typeof(DoubleConverter))]
        public double TotalNetAmount { get; set; }

        [FixedLengthField(12, 84, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string Entities { get; set; }

        [FixedLengthField(13, 250, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string UserArea { get; set; }
    }
}


/*
Codes as follows:
Fund01 X8000B8000000000
Fund02 X8002B8000000000
Fund07 X5400B8000000000
Fund15 4R54250003000000
*/
