using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace dllCalculator
{
    public class Derivative: Function<double>
    {
        public string Name
        {
            get { return "Derivative"; }
        }

        public string HelpMessage
        {
            get { return "This function evaluates the derivative of a polynom at a point\r\n" +
                    "You need to give 2 arguments\r\n" +
                    "First argument: each coefficient in descending order of degrees\r\n" +
                    "Second argument: the point where you want an evaluation of the derivative of the polynom" +
                    "ex: the derivative of x^2 + 3 to evaluate in point 3--> Derivative 1,0,3 3"; }
        }

        public string[] ParametersName
        {
            get { return new string[] { "polynom", "point" }; }
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
                throw new EvaluationException("The parameters need to be integer");
            }
            catch (IndexOutOfRangeException)
            {
                throw new EvaluationException("Not enough argument given");
            }
        }
        private double DerivatePoly(double[] f, double x)
        {
            double xplusdx = x + Convert.ToDouble(1e-7);
            double xminusdx = x - Convert.ToDouble(1e-7);
            int n = f.Count() - 1;
            double fxplusdx = 0;
            double fxminusdx = 0;
            double result = 0;

            foreach (int i in f)
            {
                fxplusdx += i * Math.Pow(xplusdx, n);
                n--;            }

            n = f.Count() - 1;

            foreach (int i in f)
            {
                fxminusdx += i * Math.Pow(xminusdx, n);
                n--;
            }

            result = (fxplusdx - fxminusdx) / (2 * Convert.ToDouble(1e-7));
            return result;
        }
    }
}
