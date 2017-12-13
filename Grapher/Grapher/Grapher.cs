using System;
using SuperComputer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    public class Grapher : Function<string>
    {
        public string Name
        {
            get { return "graph"; }
        }
        public string HelpMessage
        {
            get { return "graph a \n graphe une fonction entre x=0 et x=0"; }
        }
        public string[] ParametersName
        {
            get { return new string[] { "a" }; }
        }
        public string Evaluate(string[] args)
        {
            double output = 0;
            int[] polynom;
            int xi;
            int xf;
            try
            {
                polynom = Array.ConvertAll(args[0].Split(','), x => Convert.ToInt32(x));
                xi = Convert.ToInt32(args[1]);
                xf = Convert.ToInt32(args[2]);
            }
            catch (FormatException)
            {
                throw new EvaluationException("Couldn't interpret your polynom");
            }

            List<double> vals = new List<double>();
            for(int x = xi; x < xf; x++ )
            {
                vals.Add(EvalPoly(polynom, x));
            }

            double max = vals.Max();
            double min = vals.Min();
            int ydist = Convert.ToInt32(max - min);
            int xdist = Convert.ToInt32(xf - xi);

            char[,] graph = new char[,] {};
            
 
            return EvalPoly(polynom, 2).ToString();
        }
        private double EvalPoly(int[] poly, double x)
        {
            int n = poly.Count() - 1;
            double result = 0;

            foreach(int i in poly)
            {
                result += i * Math.Pow(x, n);
                n--;
            }

            return result;
        }
    }
}
