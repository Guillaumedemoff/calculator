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
        private int fctlen = 2;

        public Form1()
        {
            InitializeComponent();
            foreach (IFunction f in Program.fct)
            {
                AutoCompleteBox.AutoCompleteCustomSource.Add(f.Name);
            }
            AutoCompleteBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                }

                catch(TargetInvocationException tie)
                {
                   if(tie.InnerException is IndexOutOfRangeException)
                    {
                        MessageBox.Show("Not enough parameter");
                    }
                   else if(tie.InnerException is EvaluationException)
                    {
                        MessageBox.Show("Evaluation Error: \n" + tie.Message);
                    }
                    else
                    {
                        MessageBox.Show("Error :" + tie.Message);
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

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
           if(InputBox.SelectionStart <= fctlen) 
                AutoCompleteBox.Visible = true;
            AutoCompleteBox.Text = InputBox.Text;
            AutoCompleteBox.Focus();
            AutoCompleteBox.Select(AutoCompleteBox.Text.Length, 0);
        }

        private void InputBox_Leave(object sender, EventArgs e)
        {
            
            if(!AutoCompleteBox.Focused)
            {
                AutoCompleteBox.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void AutoCompleteBox_SelectedValueChanged(object sender, EventArgs e)
        {
            InputBox.Text = AutoCompleteBox.Text + " ";
            fctlen = AutoCompleteBox.Text.Length-1;
            AutoCompleteBox.Visible = false;
            InputBox.Focus();
            InputBox.Select(InputBox.Text.Length, 0);
        }

    }
}
