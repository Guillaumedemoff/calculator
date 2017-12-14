using System;
using SuperComputer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForm
{
    static class Program
    {
        internal static BindingSource bs = new BindingSource();
        internal static List<IFunction> fct = new List<IFunction>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DLLInfo d1 = new DLLInfo(@"C:\Users\guill\source\repos\calculator\ClassLibrary1\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
            DLLInfo d2 = new DLLInfo(@"C:\Users\guill\source\repos\calculator\Grapher\Grapher\bin\Debug\Grapher.dll");
            bs.DataSource = typeof(DLLInfo);
            bs.Add(d1);
            bs.Add(d2);
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new FunctionForm());
        }
    }
}
