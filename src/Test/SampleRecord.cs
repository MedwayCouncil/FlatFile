using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;

namespace Test
{
    [FixedLengthFile]
    public class SampleRecord
    {
        [FixedLengthField(1, 5, PaddingChar = '0')]
        public int Id { get; set; }
        
        [FixedLengthField(2, 25, PaddingChar = ' ', Padding = Padding.Right)]
        public string Description { get; set; }

        [FixedLengthField(3, 5, PaddingChar = '0', NullValue = "")]
        public int? NullableInt { get; set; }

   
    }
}
