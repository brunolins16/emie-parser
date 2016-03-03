namespace EMIE.Parser.UI.Win.UserControls
{
    partial class DuplicateListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgwDomain = new System.Windows.Forms.DataGridView();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDomain)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(846, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exportar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 47);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(161)))));
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Passo 3 -> Seleção de duplicados";
            // 
            // dgwDomain
            // 
            this.dgwDomain.AllowUserToAddRows = false;
            this.dgwDomain.AllowUserToDeleteRows = false;
            this.dgwDomain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDomain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Path,
            this.DocMode});
            this.dgwDomain.Location = new System.Drawing.Point(13, 52);
            this.dgwDomain.Name = "dgwDomain";
            this.dgwDomain.RowTemplate.Height = 24;
            this.dgwDomain.Size = new System.Drawing.Size(966, 457);
            this.dgwDomain.TabIndex = 1;
            this.dgwDomain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgwDomain_DataBindingComplete);
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Path.DataPropertyName = "Key";
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            // 
            // DocMode
            // 
            this.DocMode.HeaderText = "DocMode";
            this.DocMode.Name = "DocMode";
            // 
            // DuplicateListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgwDomain);
            this.Name = "DuplicateListControl";
            this.Size = new System.Drawing.Size(990, 559);
            this.Load += new System.EventHandler(this.DuplicateListControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDomain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgwDomain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewComboBoxColumn DocMode;
        private System.Windows.Forms.Button button1;
    }
}
