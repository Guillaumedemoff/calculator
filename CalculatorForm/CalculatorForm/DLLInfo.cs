using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForm
{
    class DLLInfo
    {
        private string bla = "fsd";
        private string path;
        
        private List<string> functions = new List<string>();

        public DLLInfo(string path)
        {
            this.path = path;
            functions.Add("add");
        }
        public DLLInfo() { functions.Add("add"); }



        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public string Bla
        {
            get { return bla; }
            set { bla = value; }
        }

        public List<String> Functions
        {
            get { return functions; }
       
        }
    }
}
