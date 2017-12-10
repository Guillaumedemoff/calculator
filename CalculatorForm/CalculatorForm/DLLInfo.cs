using System;
using System.Collections.Generic;
using System.Reflection;
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
        
        private List<Type> functions = new List<Type>();

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
                        functions.Add(t);
                    } 
                }
                catch
                {
                    MessageBox.Show("Could not charge dll from: " + path);
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

        public List<Type> Functions
        {
            get { return new List<Type>(functions); }
        }
    }
}
