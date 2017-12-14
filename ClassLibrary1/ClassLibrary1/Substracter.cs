﻿// Adder.cs

using System;
using SuperComputer;

namespace Combefis
{
    public class Substracter : Function<int>
    {
        public string Name
        {
            get { return "moins"; }
        }

        public string HelpMessage
        {
            get { return "add a b\nCalcule la différence des deux entiers c et d."; }
        }

        public string[] ParametersName
        {
            get { return new string[] { "c", "d" }; }
        }

        public int Evaluate(string[] args)
        {
            try
            {
                return 42;
            }
            catch (FormatException)
            {
                throw new EvaluationException("Les deux paramètres doivent être des entiers.");
            }
        }
    }
}