using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Custom_Format_Provider
{
    public class HexadecimalFormatProvider : IFormatProvider, ICustomFormatter
    {
        IFormatProvider provider;

        public HexadecimalFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public HexadecimalFormatProvider(IFormatProvider provider)
        {
            this.provider = provider;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null) return arg.ToString();

            bool IsSupportedFormat = false;
            if (String.Compare(format, "hex") == 0)
                IsSupportedFormat = true;
            else if (String.Compare(format, "HEX") == 0)
                IsSupportedFormat = true;

            try
            {
                if (arg == null || IsSupportedFormat == false)
                    return string.Format(provider, "{0:" + format + "}", arg);
            }
            catch (FormatException)
            {
                //throw new FormatException("Format specifier was invalid.");
                throw;
            }
            catch(ArgumentNullException)
            {
                throw;
            }


            string result = ConvertFromDecToHex(arg);

            if (String.Compare(format, "hex") == 0)
                return result;
            else return result.ToUpper(CultureInfo.InvariantCulture);
        }

        private static string ConvertFromDecToHex(object arg)
        {
            Type argType = arg.GetType();

            if (argType != typeof(Int16) && argType != typeof(Int32) && argType != typeof(Int64)
                && argType != typeof(Byte) && argType != typeof(SByte) && argType != typeof(UInt16)
                && argType != typeof(UInt32) && argType != typeof(UInt64) && argType != typeof(Char))
            {
                return arg.ToString();
            }

            char[] baseSymbols = new char[16]
            {
                '0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'
            };

            ulong number = ConvertFromBoxValueToUlong(arg);
            ulong modulo;

            StringBuilder result = new StringBuilder();

            while (number >= 16)
            {
                modulo = number % 16;
                result.Append(baseSymbols[modulo]);
                number = number / 16;
            }
            result.Append(baseSymbols[number]);

            IEnumerable<char> rightSequence = result.ToString().Reverse();

            result.Clear().Append(rightSequence.ToArray<char>());
            return result.ToString();
        }

        private static ulong ConvertFromBoxValueToUlong(object arg)
        {
            Type argType = arg.GetType();

            if (argType == typeof(UInt64))
            {
                return (ulong)arg;
            }

            if (argType == typeof(Int64))
            {
                Int64 temp = (Int64)arg;
                return (ulong)temp;
            }

            if (argType == typeof(Int32))
            {
                Int32 temp = (Int32)arg;
                return (ulong)temp;
            }

            if (argType == typeof(UInt32))
            {
                UInt32 temp = (UInt32)arg;
                return (ulong)temp;
            }

            if (argType == typeof(Int16))
            {
                Int16 temp = (Int16)arg;
                return (ulong)temp;
            }

            if (argType == typeof(UInt16))
            {
                UInt16 temp = (UInt16)arg;
                return (ulong)temp;
            }

            if (argType == typeof(SByte))
            {
                SByte temp = (SByte)arg;
                return (ulong)temp;
            }

            if (argType == typeof(Byte))
            {
                Byte temp = (Byte)arg;
                return (ulong)temp;
            }

            if (argType == typeof(Char))
            {
                Char temp = (Char)arg;
                return (ulong)temp;
            }           

            return 0;
        }

        #region Using dynamic type

        /*
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null) return arg.ToString();

            bool IsSupportedFormat = false;
            if (String.Compare(format, "hex") == 0)
                IsSupportedFormat = true;
            else if (String.Compare(format, "HEX") == 0)
                IsSupportedFormat = true;

            try
            {
                if (arg == null || IsSupportedFormat == false)
                    return string.Format(provider, "{0:" + format + "}", arg);
            }
            catch (FormatException)
            {
                //throw new FormatException("Format specifier was invalid.");
                throw;
            }

            char[] baseSymbols = new char[16]
            {
                '0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'
            };

            dynamic tempNumber = arg;

            StringBuilder result = new StringBuilder();

            ulong modulo;
            ulong number;

            try
            {
                number = (ulong)tempNumber;
            }
            catch (OverflowException)
            {
                throw new OverflowException("Argument was too big.");
            }
            catch (Exception)
            {
                throw new ArgumentException("Wrong argument type.");
            }

            while (number >= 16)
            {
                modulo = number % 16;
                result.Append(baseSymbols[modulo]);
                number = number / 16;
            }
            result.Append(baseSymbols[number]);

            IEnumerable<char> rightSequence = result.ToString().Reverse();

            result.Clear().Append(rightSequence.ToArray<char>());            

            if (String.Compare(format, "hex") == 0)
                return result;
            else return result.ToUpper(CultureInfo.InvariantCulture);
        }
        */

        #endregion
    }
}
