using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                if (args[0] == "b")
                {
                    string pattern = @"[01]+";
                    foreach (Match m in Regex.Matches(args[1], pattern))
                    {
                        if (args[1].Length == m.Length)
                        {
                            double dec = Convert.ToInt64(args[1], 2);
                            return dec.ToString();
                        }
                        else
                        {
                            throw new EvaluationException("Veuillez entrer un b ou un d suivi d'une virgule et d'un nombre binaire ou décimal");
                        }
                    }
                }
                if (args[0] == "d")
                {
                    double num = Convert.ToDouble(args[1]);
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
                    throw new EvaluationException("Veuillez entrer un b ou un d suivi d'une virgule et d'un nombre binaire ou décimal");
                }
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les deux paramètres doivent être des chaines de caractères séparées par une virgule.");
            }
        }
    }
}