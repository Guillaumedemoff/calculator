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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DllFunctions = new System.Windows.Forms.ListBox();
            this.functionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dLLInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DllsPath = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLLInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DllsPath)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Library (*.dll)|*.dll";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // DllFunctions
            // 
            this.DllFunctions.FormattingEnabled = true;
            this.DllFunctions.ItemHeight = 25;
            this.DllFunctions.Location = new System.Drawing.Point(910, 60);
            this.DllFunctions.Margin = new System.Windows.Forms.Padding(6);
            this.DllFunctions.Name = "DllFunctions";
            this.DllFunctions.Size = new System.Drawing.Size(432, 654);
            this.DllFunctions.TabIndex = 4;
            // 
            // functionsBindingSource
            // 
            this.functionsBindingSource.DataMember = "Functions";
            this.functionsBindingSource.DataSource = this.dLLInfoBindingSource;
            // 
            // dLLInfoBindingSource
            // 
            this.dLLInfoBindingSource.DataSource = typeof(CalculatorForm.DLLInfo);
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
            this.DllsPath.VirtualMode = true;
            this.DllsPath.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DllsPath_NewRowNeeded);
            this.DllsPath.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DllsPath_UserDeletingRow);
            // 
            // FunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 752);
            this.Controls.Add(this.DllsPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DllFunctions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FunctionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Manager";
            this.Load += new System.EventHandler(this.FunctionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dLLInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DllsPath)).EndInit();
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
    }
}