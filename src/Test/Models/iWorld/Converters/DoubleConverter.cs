using FlatFile.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.iWorld.Converters
{
    public class DoubleConverter : ITypeConverter
    {
        public bool CanConvertFrom(Type type)
        {
            return type == typeof(string);
        }

        public bool CanConvertTo(Type type)
        {
            return type == typeof(double);
        }

        public object ConvertFromString(string source)
        {
            return double.Parse(source);

        }

        public string ConvertToString(object source)
        {
            if ((double)source > 0.0)
            {
                return ((double)source).ToString("00000000000.00");
            }
            else
            {
                return ((double)source).ToString("0000000000.00");
            }
        }
    }
}
