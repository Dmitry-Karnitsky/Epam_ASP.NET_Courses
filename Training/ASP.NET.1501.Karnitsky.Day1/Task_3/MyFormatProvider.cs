using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task_3
{
    public class MyFormatProvider : IFormatProvider, ICustomFormatter
    {
        private char[] baseSymbols = new char[16]
        {
            '0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'
        };



        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {                
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(System.Int32)) return arg.ToString();            
            StringBuilder result = new StringBuilder();
            int tempNumber = (int)arg;
            switch (format)
            {
                case "hex":
                    uint modulo;
                    UInt32 number = (uint)tempNumber;                

                    while (number >= 16)
                    {
                        modulo = number % 16;
                        result.Append(baseSymbols[modulo]);
                        number = number / 16;
                    }
                    result.Append(baseSymbols[number]);

                    for (int i = 0; i < result.Length/2; i++)
                    {
                        char temp = result[i];
                        result[i] = result[result.Length - i - 1];
                        result[result.Length - i - 1] = temp;                        
                    }
                    return result.ToString();
                default:
                    throw new FormatException();
            }
        }
    }
}
