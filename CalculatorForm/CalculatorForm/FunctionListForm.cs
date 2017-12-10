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
            BindingSource bsFct = new BindingSource();
            bsFct.DataSource = Program.bs;
            bsFct.DataMember = "Functions";

            listBox1.DataSource = bsFct;
            listBox1.DisplayMember = "Name";

            BindingSource bsPrm = new BindingSource();
            bsPrm.DataSource = bsFct;
            bsPrm.DataMember = "ParametersName";
            parametersBox.DataSource = bsPrm;

            helpBox.DataBindings.Add("Text", bsFct, "HelpMessage");
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
