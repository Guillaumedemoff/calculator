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
            get { return "BinairyConverter"; }
        }

        public string HelpMessage
        {
            get { return "This function converts a decimal number to a binairy number and connversely\r\nYou need to give 2 arguments\r\n" +
                    "First agument: d for décimal or b for binaire" +
                    "Second argument: the number" +
                    "ex: to convert a binairy number 1001 to decimal--> BinairyConverter b 1001"; }
        }

        public string[] ParametersName
        {
            get { return new string[] { "type", "number" }; }
        }

        public string Evaluate(string[] args)
        {
            if(args.Count() < 2)
            {
                throw new EvaluationException("Not enough argument given");
            }

            if (args[0] == "b")
            {
                string pattern = @"[01]+";
                MatchCollection matches = Regex.Matches(args[1], pattern);
                if (matches.Count == 0)
                {
                    throw new EvaluationException("Please enter a binairy number");
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
                            throw new EvaluationException("Please consult the help message to respect the format");

                        }

                    }
                    else
                    {
                        throw new EvaluationException("Please consult the help message to respect the format");
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
                    throw new EvaluationException("The second parameter needs to be an integer");
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
                throw new EvaluationException("The first parameter needs to be a b for binairy or a d for decimal");
            }

            return null;
        }
    }
}