using FlatFile.Core;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.iWorld.Converters;

namespace Test.Models.iWorld.CtxBr
{
    [FixedLengthFile]
    public class CtxBrHeader
    {
        [FixedLengthField(1, 20, PaddingChar = ' ', Padding = Padding.Right)]
        public string FileUniqueIdentifier { get; set; }

        [FixedLengthField(2, 5, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string FileVersion { get; set; }

        [FixedLengthField(3, 121, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string FillerVersion { get; set; }
    }

    [FixedLengthFile]
    public class CtxBrRecord
    {
        [FixedLengthField(1, 15, PaddingChar = ' ', Padding = Padding.Right)]
        public string AccountNo { get; set; }

        [FixedLengthField(2, 1)]
        public string AccountCheckDigit { get; set; }

        [FixedLengthField(3, 2, PaddingChar = ' ', Padding = Padding.Right, NullValue = " ")]
        public string YearIdentifier { get; set; } //blank

        [FixedLengthField(4, 2, PaddingChar = ' ', Padding = Padding.Right)]
        public int ReceivingMethod { get; set; }

        [FixedLengthField(5, 14, PaddingChar = '0', Padding = Padding.Left, Converter = typeof(DoubleConverter))]
        public double Amount { get; set; }

        [FixedLengthField(6, 2, PaddingChar = ' ', Padding = Padding.Right)]
        public string FundReference { get; set; }

        [FixedLengthField(7, 11, PaddingChar = ' ', Padding = Padding.Right, Converter = typeof(DateTimeConverter))]
        public DateTime DateReceivedAtSource { get; set; }

        [FixedLengthField(8, 20, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string TransferInFormFund { get; set; } //blank

        [FixedLengthField(9, 12, PaddingChar = ' ', Padding = Padding.Right)]
        public string UniqueSourceSystemReference { get; set; }

        [FixedLengthField(10, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string Blank1 { get; set; }//blank

        [FixedLengthField(11, 3, PaddingChar = ' ', Padding = Padding.Right)]
        public string SourceSystemCode { get; set; }

        [FixedLengthField(12, 3, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string Blank2 { get; set; }//blank

        [FixedLengthField(13, 4, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string ReasonForReturn { get; set; }//blank

        [FixedLengthField(14, 1, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string RecoveredViaBailif { get; set; }//blank

        [FixedLengthField(15, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string BailiffShortName { get; set; }//blank

        [FixedLengthField(16, 8, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string BankAccountNo { get; set; }//blank

        [FixedLengthField(17, 6, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string BankSortCode { get; set; }//blank

        [FixedLengthField(18, 18, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string OriginatorsReference { get; set; }//blank

        [FixedLengthField(19, 12, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string BatchNumber { get; set; }//blank

        [FixedLengthField(20, 10, PaddingChar = ' ', Padding = Padding.Right, NullValue = "")]
        public string LiabilityOrderReference { get; set; }//blank

    }
}
