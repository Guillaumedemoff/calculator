using System;
using SuperComputer;
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
                foreach (IFunction f in di.Functions)
                {
                    fct.Add(f);
                    

                }
            }
            listBox1.DataSource = fct;
            listBox1.DisplayMember = "Name";

            BindingSource bsPrm = new BindingSource();
            bsPrm.DataSource = fct;
            bsPrm.DataMember = "ParametersName";
            parametersBox.DataSource = bsPrm;

            helpBox.Text = ((IFunction)fct.Current).HelpMessage;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void helpBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
