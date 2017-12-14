using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllCalculator
{
    public class Derivative: Function<double>
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
                double[] f = Array.ConvertAll(args[0].Split(','), part => Convert.ToDouble(part));
                double x = Convert.ToInt32(args[1]);
                return DerivatePoly(f, x);
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les paramètres doivent être des entiers.");
            }
        }
        private double DerivatePoly(double[] f, double x)
        {
            double xplusdx = x + double.Epsilon;
            double xminusdx = x - double.Epsilon;
            int n = f.Count() - 1;
            double fxplusdx = 0;
            double fxminusdx = 0;
            double result = 0;

            foreach (int i in f)
            {
                fxplusdx += i * Math.Pow(xplusdx, n);
                n--;
            }

            foreach (int i in f)
            {
                fxminusdx += i * Math.Pow(xminusdx, n);
                n--;
            }

            result = (fxplusdx - fxminusdx) / (2 * double.Epsilon);
            return result;
        }
    }
}
