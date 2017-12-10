using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorForm
{
    public partial class FunctionListForm : Form
    {
        public FunctionListForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FunctionListForm_Load(object sender, EventArgs e)
        {
            BindingSource fct = new BindingSource();
            foreach(DLLInfo di in Program.bs)
            {

                foreach (Type f in di.Functions)
                    fct.Add(f.Name);
            }
            listBox1.DataSource =fct;
        }
    }
}
