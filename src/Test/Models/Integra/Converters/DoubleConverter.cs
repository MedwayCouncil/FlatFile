using FlatFile.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Integra.Converters
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
                //if PaymentType=P then leading negative
                return (-1*(double)source).ToString("0000000.00");
            }
            else
            {
                //if PaymentType=R then leading +
                return (-1 * (double)source).ToString("00000000.00");
            }
        }
    }
}
