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

            int n = polynom.Count() - 1;
            double result = 0;

            foreach (int i in polynom)
            {
                result += i * Math.Pow(x, n);
                n--;
            }
            return result.ToString();
        }

    }
}
