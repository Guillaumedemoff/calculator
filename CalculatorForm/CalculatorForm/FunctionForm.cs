using System;
using System.IO;
using SuperComputer;
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
            
            DllsPath.DataSource = Program.bs;
            DllsPath.AutoGenerateColumns = true;

            DllFunctions.DataSource = Program.bs;
            
            DllFunctions.DisplayMember = "Functions.Name";


            Program.bs.AllowNew = true;
            ((BindingList<DLLInfo>)Program.bs.List).AllowRemove = true;
            DllsPath.Columns[0].Width = DllsPath.Width;
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
                    MessageBox.Show("Could not open file");
                }
            }
        }

        private void DllsPath_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DLLInfo dllInfo = (DLLInfo)Program.bs.List[e.Row.Index];
            foreach(IFunction f in dllInfo.Functions)
            {
                Program.fct.Remove(f);
            }
        }
    }
}
