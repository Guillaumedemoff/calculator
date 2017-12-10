using System;
using System.Collections.Generic;
using System.Reflection;
using SuperComputer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace CalculatorForm
{
    class DLLInfo
    {
        private string path;
        
        private List<IFunction> functions = new List<IFunction>();

        public DLLInfo(string path)
        {
            this.path = path;
            InitFnc();
        }


        public DLLInfo(){}


        private void InitFnc()
        {
            if (path != "")
            {
                try
                {
                    Assembly dll = Assembly.LoadFile(path);
                    Type[] types = dll.GetExportedTypes();
                    foreach (Type t in types)
                    {
                        functions.Add((IFunction)Activator.CreateInstance(t));
                    } 
                }
                catch(Exception e)
                {
                    MessageBox.Show("Could not charge dll from: " + path +"\n" + e.Message);
                }

            }
        }
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                InitFnc();
            }
        }

        public List<IFunction> Functions
        {
            get { return new List<IFunction>(functions); }
        }
    }
}
