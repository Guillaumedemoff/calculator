﻿using System;
using SuperComputer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForm
{
    static class Program
    {
        internal static List<IFunction> fct = new List<IFunction>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                        
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new FunctionForm());
        }
    }
}
