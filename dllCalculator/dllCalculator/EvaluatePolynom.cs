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
                throw new EvaluationException("Not Enough Argument");
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
