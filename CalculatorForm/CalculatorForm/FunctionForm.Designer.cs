namespace CalculatorForm
{
    partial class FunctionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DllFunctions = new System.Windows.Forms.ListBox();
            this.functionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DllsPath = new System.Windows.Forms.DataGridView();
            this.addPathButton = new System.Windows.Forms.Button();
            this.dLLInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DllsPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLLInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Library (*.dll)|*.dll";
            // 
            // DllFunctions
            // 
            this.DllFunctions.FormattingEnabled = true;
            this.DllFunctions.ItemHeight = 25;
            this.DllFunctions.Location = new System.Drawing.Point(910, 60);
            this.DllFunctions.Margin = new System.Windows.Forms.Padding(6);
            this.DllFunctions.Name = "DllFunctions";
            this.DllFunctions.Size = new System.Drawing.Size(432, 579);
            this.DllFunctions.TabIndex = 4;
            // 
            // functionsBindingSource
            // 
            this.functionsBindingSource.DataMember = "Functions";
            this.functionsBindingSource.DataSource = this.dLLInfoBindingSource;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(912, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fonctions disponibles :";
            // 
            // DllsPath
            // 
            this.DllsPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DllsPath.Location = new System.Drawing.Point(24, 23);
            this.DllsPath.Margin = new System.Windows.Forms.Padding(6);
            this.DllsPath.Name = "DllsPath";
            this.DllsPath.ReadOnly = true;
            this.DllsPath.Size = new System.Drawing.Size(852, 694);
            this.DllsPath.TabIndex = 7;
            this.DllsPath.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DllsPath_NewRowNeeded);
            this.DllsPath.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DllsPath_UserDeletingRow);
            // 
            // addPathButton
            // 
            this.addPathButton.Location = new System.Drawing.Point(918, 671);
            this.addPathButton.Margin = new System.Windows.Forms.Padding(6);
            this.addPathButton.Name = "addPathButton";
            this.addPathButton.Size = new System.Drawing.Size(428, 44);
            this.addPathButton.TabIndex = 8;
            this.addPathButton.Text = "Add path";
            this.addPathButton.UseVisualStyleBackColor = true;
            this.addPathButton.Click += new System.EventHandler(this.addPathButton_Click);
            // 
            // dLLInfoBindingSource
            // 
            this.dLLInfoBindingSource.DataSource = typeof(CalculatorForm.DLLInfo);
            // 
            // FunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 752);
            this.Controls.Add(this.addPathButton);
            this.Controls.Add(this.DllsPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DllFunctions);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FunctionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FunctionForm";
            this.Load += new System.EventHandler(this.FunctionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DllsPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLLInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox DllFunctions;
        private System.Windows.Forms.BindingSource dLLInfoBindingSource;
        private System.Windows.Forms.BindingSource functionsBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DllsPath;
        private System.Windows.Forms.Button addPathButton;
    }
}