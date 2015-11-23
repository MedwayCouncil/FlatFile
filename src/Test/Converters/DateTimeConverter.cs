using FlatFile.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Converters
{
    public class DateTimeConverter : ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(DateTime);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(DateTime);
        }

        public object ConvertFromString(string source)
        {
            return DateTime.Parse(source);

        }

        public string ConvertToString(object source)
        {

            return ((DateTime)source).ToString("dd-MMM-yyy").ToUpper();

        }
    }
}
