using FlatFile.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Integra.Converters
{
    public class DateTimeConverter : ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(DateTime);
        }

        public object ConvertFromString(string source)
        {
            return DateTime.ParseExact(source,
                                    "yyyyMMdd",
                                    System.Globalization.CultureInfo.InvariantCulture);

        }

        public string ConvertToString(object source)
        {

            return ((DateTime)source).ToString("yyyyMMdd").ToUpper();

        }
    }
}
