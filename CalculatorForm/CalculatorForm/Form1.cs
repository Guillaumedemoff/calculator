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
    public partial class Form1 : Form
    {
        internal static AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("This will earse current data if not save",
                                     "Confirm New",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                OutputBox.Text = "";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    OutputBox.Text = File.ReadAllText(file);
                }
                catch (IOException)
                {
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                try
                {
                    File.WriteAllText(file, OutputBox.Text);
                }
                catch (IOException)
                {
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FunctionForm().Show();
        }

        private void EvaluateButton_Click(object sender, EventArgs e)
        {
            string[] cmd = InputBox.Text.Split(' ');
            string function = cmd[0];
            string[] pmrs = new string[cmd.Count()];
            Array.Copy(cmd, 1, pmrs,0, cmd.Count()-1);
            IFunction f = Program.fct.Find(x => x.Name == cmd[0]);
            if (f != null)
            {
                try
                {
                    MethodInfo method = f.GetType().GetMethod("Evaluate");
                    object a = method.Invoke(f,new object[] {pmrs});
                    OutputBox.Text +=String.Format("> {0}\n\t{1}\n", InputBox.Text, a.ToString());
                    InputBox.Text = "";
                    OutputBox.Focus();
                    OutputBox.Select(OutputBox.Text.Length, 0);
                    OutputBox.ScrollToCaret();
                    InputBox.Focus();
                }

                catch(TargetInvocationException tie)
                {
                   if(tie.InnerException is EvaluationException)
                    {
                        MessageBox.Show("Evaluation Error: \n" + tie.InnerException.Message);
                    }
                    else
                    {
                        MessageBox.Show("Error :" + tie.InnerException.Message);
                    }
                }

            }
            else
                MessageBox.Show("Function not found");
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FunctionListForm().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            foreach (IFunction f in Program.fct)
            {
                autoCompleteStringCollection.Add(f.Name);
            }
            InputBox.AutoCompleteCustomSource = autoCompleteStringCollection;

            InputBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            InputBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

    }
}
