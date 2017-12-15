using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperComputer;

namespace dllCalculator
{
    public class EvaluatePolynom: Function<int>
    {
        public string Name
        {
            get { return "EvaluatePolynom"; }
        }
        public string HelpMessage
        {
            get { return "This function evaluates a polynom at a point\r\nYou need to give 2 arguments\r\n" +
                    "First argument: each coefficient in descending order of degrees\r\n" +
                    "Second argument: the point where you want an evaluation of the polynom" +
                    "ex: x^2 + 3 to evaluate in point 3--> EvaluatePolynom 1,0,3 3"; }
        }
        public string[] ParametersName
        {
            get { return new string[] { "polynom", "point" }; }
        }
        public int Evaluate(string[] args)
        {
            int[] polynom;
            int x;
            try
            {
                polynom = Array.ConvertAll(args[0].Split(','), i => Convert.ToInt32(i));
                x = Convert.ToInt32(args[1]);
            }
            catch (FormatException)
            {
                throw new EvaluationException("Couldn't interpret your polynom");
            }
            catch(IndexOutOfRangeException)
            {
                throw new EvaluationException("Not Enough Argument given");
            }

            int n = polynom.Count() - 1;
            int result = 0;

            foreach (int i in polynom)
            {
                result += Convert.ToInt32(i * Math.Pow(x, n));
                n--;
            }
            return result;
        }
    }
}
