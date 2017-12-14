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
                        if(typeof(IFunction).IsAssignableFrom(t))
                        {
                            IFunction f = (IFunction)Activator.CreateInstance(t);
                            if(f.Name != "")
                            {
                                functions.Add(f);
                                Program.fct.Add(f);
                                Form1.autoCompleteStringCollection.Add(f.Name);
                            }
                            else
                            {
                                MessageBox.Show("a function couldn't be imported beause it has no name");
                            }
                        }
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
