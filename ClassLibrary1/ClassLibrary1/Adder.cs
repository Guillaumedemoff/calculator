// Adder.cs

using System;
using SuperComputer;

namespace Combefis
{
    public class Adder : Function<int>
    {
        public string Name
        {
            get { return "Additionnateur"; }
        }

        public string HelpMessage
        {
            get { return "add a b\nCalcule la somme des deux entiers a et b."; }
        }

        public string[] ParametersName
        {
            get { return new string[] {"a", "b"}; }
        }

        public int Evaluate (string[] args)
        {
            try
            {
                return Convert.ToInt32 (args[0]) + Convert.ToInt32(args[1]);
            }
            catch (FormatException)
            {
                throw new EvaluationException ("Les deux paramètres doivent être des entiers.");
            }
        }
    }
}
