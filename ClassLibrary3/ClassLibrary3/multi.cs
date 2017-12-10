// Adder.cs

using System;
using SuperComputer;

namespace Combefis
{
    public class Multi : Function<string>
    {
        public string Name
        {
            get { return "M"; }
        }

        public string HelpMessage
        {
            get { return "add a b\nCalcule la multiplication des deux entiers a et b."; }
        }

        public string[] ParametersName
        {
            get { return new string[] {"a", "b"}; }
        }

        public string Evaluate (string[] args)
        {
            try
            {
                return "coucou";
                
            }
            catch (FormatException)
            {
                throw new EvaluationException ("Les deux paramètres doivent être des entiers.");
            }
        }
    }
}
