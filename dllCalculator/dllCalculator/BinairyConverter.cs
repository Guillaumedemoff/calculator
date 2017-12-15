using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SuperComputer;

namespace dllCalculator
{
    public class BinairyConverter : Function<string>
    {
        public string Name
        {
            get { return "convertisseur"; }
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
            if(args.Count() < 2)
            {
                throw new EvaluationException("Not Enough Argument");
            }

            if (args[0] == "b")
            {
                string pattern = @"[01]+";
                MatchCollection matches = Regex.Matches(args[1], pattern);
                if (matches.Count == 0)
                {
                    throw new EvaluationException("Veiller entrer un nombre binaire");
                }
                foreach (Match m in matches)
                {
                    if (args[1].Length == m.Length)
                    {
                        int dec;
                        try
                        {
                            dec = Convert.ToInt32(args[1], 2);
                            return dec.ToString();
                        }
                        catch(FormatException)
                        {
                            throw new EvaluationException("Veuillez entrer un b ou un d suivi d'une virgule et d'un nombre binaire ou décimal");

                        }

                    }
                    else
                    {
                        throw new EvaluationException("Veuillez entrer un b ou un d suivi d'une virgule et d'un nombre binaire ou décimal");
                    }
                }
            }
            else if (args[0] == "d")
            {
                int num;
                try
                {
                    num = Convert.ToInt32(args[1]);
                }
                catch(FormatException)
                {
                    throw new EvaluationException("Le deuxième paramètre doit etre un entier");
                }

                string result = "";
                Stack<string> binaryResult = new Stack<string>();
                while (num > 0)
                {
                    int rem = num % 2;
                    binaryResult.Push(rem.ToString());
                    num /= 2;
                }

                while(binaryResult.Count > 0)
                {
                    result += binaryResult.Pop();
                }
                return result;
            }
            else
            {
                throw new EvaluationException("Le premier paramètre doit etre un b ou un d");
            }

            return null;
        }
    }
}