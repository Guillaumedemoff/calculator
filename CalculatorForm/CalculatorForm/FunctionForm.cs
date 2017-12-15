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
        internal static BindingSource bs = new BindingSource();
        public FunctionForm()
        {
            InitializeComponent();

        }

        private void FunctionForm_Load(object sender, EventArgs e)
        {
            bs.DataSource = typeof(DLLInfo);
            DllsPath.DataSource = bs;
            DllsPath.AutoGenerateColumns = true;

            DllFunctions.DataSource = bs;
            
            DllFunctions.DisplayMember = "Functions.Name";


            bs.AllowNew = true;
            ((BindingList<DLLInfo>)bs.List).AllowRemove = true;
            DllsPath.Columns[0].Width = DllsPath.Width;
        }

        private void DllsPath_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DLLInfo dllInfo = (DLLInfo)bs.List[e.Row.Index];
            foreach(IFunction f in dllInfo.Functions)
            {
                Program.fct.Remove(f);
                Form1.autoCompleteStringCollection.Remove(f.Name);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string file = openFileDialog1.FileName;

            try
            {
                bs.Add(new DLLInfo(file));
            }
            catch (IOException)
            {
                MessageBox.Show("Could not open file");
            }
        }

        private void DllsPath_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            bs.RemoveCurrent();
            DialogResult result = openFileDialog1.ShowDialog();
        }
    }
}