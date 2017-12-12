using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllCalculator
{
    public class BinairyConverter : Function<string>
    {
        public string Name
        {
            get { return "convertisseur décimal/binaire"; }
        }

        public string HelpMessage
        {
            get { return "Convert decimal to binairy and inversely\r\nConvertit de décimal à binaire et inversément\r\nd: décimal et b: binaire"; }
        }

        public string[] ParametersName
        {
            get { return new string[] { "type", "nombre" }; }
        }

        public string Evaluate(string[] args)
        {
            try
            {
                if ("type" == "b")
                {
                    double dec = Convert.ToInt64("nombre", 2);
                    return dec.ToString();
                }

                if ("type" == "d")
                {
                    double num = Convert.ToDouble("nombre");
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
                    //raise format exception ?
                    return "0";
                }
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les deux paramètres doivent être des chaines de caractères séparées par une virgule.");
            }
        }
    }
}