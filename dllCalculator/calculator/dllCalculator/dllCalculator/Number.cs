using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllCalculator
{
    public class Number
    {
        private string format;
        private string numeral;

        public Number (string format, string numeral)
        {
            this.format = format;
            this.numeral = numeral;
        }

        public string GetFormat => format;
        public string GetNumeral => numeral;

        public string GetConversion(Number n)
        {
            if (n.GetFormat == "b")
            {
                double dec = Convert.ToInt64(numeral, 2);
                return dec.ToString();
            }

            if (n.GetFormat == "d")
            {
                double num = Convert.ToDouble(n.GetNumeral);
                string result = string.Empty;
                while (num % 2 > 0)
                {
                    double rem = num % 2;
                    num /= 2;
                    result = rem.ToString() + result;
                }
                return result;
            }
            else
            {
                return "Enter a number please";
            }
        }
    }
}
