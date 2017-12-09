using System;
using System.IO;
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
    public partial class FunctionForm : Form
    {
        BindingSource bs = new BindingSource();
        BindingSource bs2 = new BindingSource();
        public FunctionForm()
        {
            InitializeComponent();

        }

        private void FunctionForm_Load(object sender, EventArgs e)
        {
            
            DLLInfo d1 = new DLLInfo("c:/user");
            d1.Functions.Add("ader");

            DLLInfo d2 = new DLLInfo("c:/moff");

            bs.DataSource = typeof(DLLInfo);
            bs.Add(d1);
            bs.Add(d2);

            

            dataGridView1.DataSource = bs;
            dataGridView1.AutoGenerateColumns = true;

            listBox1.DataSource = bs;
            listBox1.DisplayMember = "Functions.Name";


            ((BindingList<DLLInfo>)bs.List).AllowNew = true;
            ((BindingList<DLLInfo>)bs.List).AllowRemove = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
