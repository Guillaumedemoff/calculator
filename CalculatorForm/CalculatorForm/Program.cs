using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForm
{
    static class Program
    {
        internal static BindingSource bs = new BindingSource();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DLLInfo d1 = new DLLInfo("c:/user");

            DLLInfo d2 = new DLLInfo("c:/moff");

            Program.bs.DataSource = typeof(DLLInfo);
            Program.bs.Add(d1);
            Program.bs.Add(d2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new FunctionForm());
        }
    }
}
