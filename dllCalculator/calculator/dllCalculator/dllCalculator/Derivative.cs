using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllCalculator
{
    public class Derivative: Function<int>
    {
        public string Name
        {
            get { return "derivée"; }
        }

        public string HelpMessage
        {
            get { return "derivate a function\r\nCalcule la dérivée en un point x d'une fonction f(x)"; }
        }

        public string[] ParametersName
        {
            get { return new string[] { "f(x)", "x" }; }
        }

        public double Evaluate(string[] args)
        {
            try
            {
                (f(x + double.Epsilon) - f(x - double.Epsilon)) / (2 * double.Epsilon);  //Attention, erreur
                return Convert.ToInt32(args[0]) / Convert.ToInt32(args[1]);
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les paramètres doivent être des entiers.");
            }
        }
    }
}
