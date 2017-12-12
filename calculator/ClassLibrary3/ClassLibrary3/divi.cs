// Adder.cs

using System;
using SuperComputer;

namespace Combefis
{
    public class Divi : Function<int>
    {
        public string Name
        {
            get { return "diviseur"; }
        }

        public string HelpMessage
        {
            get { return "add a b\nCalcule la division des deux entiers c et d."; }
        }

        public string[] ParametersName
        {
            get { return new string[] { "c", "d" }; }
        }

        public int Evaluate(string[] args)
        {
            try
            {
                return Convert.ToInt32(args[0]) / Convert.ToInt32(args[1]);
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les deux paramètres doivent être des entiers.");
            }
        }
    }
}
