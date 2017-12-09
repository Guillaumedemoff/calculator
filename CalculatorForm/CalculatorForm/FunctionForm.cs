using System;
using System.IO;
using System.Reflection;
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
        
        public FunctionForm()
        {
            InitializeComponent();

        }

        private void FunctionForm_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = Program.bs;
            dataGridView1.AutoGenerateColumns = true;

            listBox1.DataSource = Program.bs;
            listBox1.DisplayMember = "Functions.Name";


            Program.bs.AllowNew = true;
            ((BindingList<DLLInfo>)Program.bs.List).AllowRemove = true;
            dataGridView1.Columns[0].Width = dataGridView1.Width;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addPathButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string file = openFileDialog1.FileName;
               
                try
                {
                    Program.bs.Add(new DLLInfo(file));
                    
                }
                catch (IOException)
                {
                }
            }
        }

    }
}
