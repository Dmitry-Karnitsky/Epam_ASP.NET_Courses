using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MathHelper
{
    public sealed class Polynomial : IFormattable
    {
        private double[] coefficients;

        private Polynomial()
        {

        }

        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null)
                throw new ArgumentNullException("Coefficients was null.");
            IEnumerable<double> rightSequence = coeffs.Reverse();
            coefficients = rightSequence.ToArray<double>();
        }

        public Polynomial(int power)
        {
            
            coefficients = new double[power + 1];
        }

        public double this[int index]
        {
            get
            {
                if (index > coefficients.Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return coefficients[index];
                }
            }

            set
            {
                if (index > coefficients.Length - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    coefficients[index] = value;
                }
            }
        }

        public int Degree
        {
            get { return coefficients.Length - 1; }
        }

        #region Operators

        public static bool operator ==(Polynomial poly1, Polynomial poly2)
        {
            if (Object.Equals(poly1, null) && Object.Equals(poly2, null))
                return true;

            if (Object.Equals(poly1, null) || Object.Equals(poly2, null))
                return false;

            if (Object.ReferenceEquals(poly1, poly2) == true)
                return true;         
   
            if (poly1.Degree != poly2.Degree) return false;
            for(int i = 0; i < poly1.Degree; i++)
            {
                if (poly1[i] == poly2[i])
                    continue;
                else return false;
            }
            return true;
        }

        public static bool operator !=(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Cannot to compare null refferences.");

            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Cannot to compare polynomial to null.");
            
            return !(poly1 == poly2);
        }

        public static Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Cannot to sum null refferences.");

            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Cannot to sum polynomial with null.");
            
            Polynomial newPoly;
            if (poly1.Degree >= poly2.Degree)
            {
                newPoly = new Polynomial(poly1.Degree);
                for (int i = 0; i <= newPoly.Degree; i++)
                {
                    if (i <= poly2.Degree)
                        newPoly[i] = poly1[i] + poly2[i];
                    else newPoly[i] = poly1[i];
                }
            }
            else
            {
                newPoly = new Polynomial(poly2.Degree);
                for (int i = 0; i <= newPoly.Degree; i++)
                {
                    if (i <= poly1.Degree)
                        newPoly[i] = poly1[i] + poly2[i];
                    else newPoly[i] = poly2[i];
                }
            }
            return newPoly;
        }

        public static Polynomial operator -(Polynomial poly)
        {
            if (poly == null)
                throw new ArgumentNullException("Cannot to negate null refference.");
            
            Polynomial newPoly = new Polynomial(poly.Degree);
            for (int i = 0; i <= poly.Degree; i++)
            {
                newPoly[i] = -poly[i];
            }
            return newPoly;
        }

        public static Polynomial operator -(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Cannot to substract null refferences.");

            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Cannot to substract polynomial and null.");
            
            Polynomial newPoly = poly1 + (-poly2);
            
            return newPoly;
        }

        public static Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Cannot to multiply null refferences.");

            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Cannot to multiply polynomial with null.");
            
            Polynomial newPoly = new Polynomial(poly1.Degree + poly2.Degree);

            for (int i = 0; i <= poly1.Degree; i++)
            {
                for (int j = 0; j <= poly2.Degree; j++)
                {
                    newPoly[i + j] += poly1[i] * poly2[j];
                }
            }
            return newPoly;

        }

        public static Polynomial operator *(Polynomial poly, double coefficient)
        {
            if (poly == null)
                throw new ArgumentNullException("Cannot to multiply null refference.");
            
            Polynomial newPoly = new Polynomial(poly.Degree);

            for (int i = 0; i <= newPoly.Degree; i++)
            {
                newPoly[i] = poly[i] * coefficient;
            }
            return newPoly;
        }

        public static Polynomial operator /(Polynomial poly, double coefficient)
        {
            if (poly == null)
                throw new ArgumentNullException("Cannot to divide null refference.");
            
            if (coefficient == 0)
            {
                throw new DivideByZeroException();
            }

            Polynomial newPoly = new Polynomial(poly.Degree);

            for (int i = 0; i <= newPoly.Degree; i++)
            {
                newPoly[i] = poly[i] / coefficient;
            }
            return newPoly;
        }
        #endregion

        public override bool Equals(object obj)
        {            
            if (obj == null || this == null) return false;
            if (obj.GetType() != typeof(Polynomial)) return false;           
            return this == (Polynomial)obj;
        }

        public override int GetHashCode()
        {
            return (int)unchecked(3571 * coefficients.Sum());
        }

        public override string ToString()
        {
            return this.ToString("S", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "S";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "S": return ConvertPolynomialToShortString();
                case "F": return ConvertPolynomialToFullString();
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        #region Polynomial Format Converters
        private string ConvertPolynomialToShortString()
        {
            StringBuilder sb = new StringBuilder();
            bool isZero = false;
            if (coefficients[coefficients.Length - 1] < 0)
            {
                sb.Append("- ");
            }
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {               
                if (coefficients[i] != 0)
                {
                    if (i != 0)
                    {
                        sb.AppendFormat("{0:R}*x^{1}", Math.Abs(coefficients[i]), i);
                    }
                    else
                    {
                        sb.AppendFormat("{0:R}", Math.Abs(coefficients[i]), i);
                    }

                    if (i != 0)
                    {
                        if (coefficients[i - 1] == 0)
                        {
                            isZero = true;
                            continue;
                        }

                        if (coefficients[i - 1] < 0)
                        {
                            sb.Append(" - ");
                        }
                        else
                            sb.Append(" + ");
                    }
                }
                if (isZero && i != 0)
                {
                    if (coefficients[i - 1] == 0)
                    {
                        isZero = true;
                        continue;
                    }

                    if (coefficients[i - 1] < 0)
                    {
                        sb.Append(" - ");
                    }
                    else
                    {
                        sb.Append(" + ");
                    }
                    isZero = false;
                }

            }
            return sb.ToString().Trim() != String.Empty ? sb.ToString() : "0";
        }
        private string ConvertPolynomialToFullString()
        {
            StringBuilder sb = new StringBuilder();
            if (coefficients[coefficients.Length - 1] < 0)
            {
                sb.Append("- ");
            }
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    sb.AppendFormat("{0:R}*x^{1}", Math.Abs(coefficients[i]), i);
                }
                else
                {
                    sb.AppendFormat("{0:R}", Math.Abs(coefficients[i]), i);
                }

                if (i != 0)
                {
                    if (coefficients[i - 1] < 0)
                    {
                        sb.Append(" - ");
                    }
                    else
                        sb.Append(" + ");
                }
            }
            return sb.ToString().Trim() != String.Empty ? sb.ToString() : "0";
        }
        #endregion
    }
}
