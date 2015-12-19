namespace EMIE.Parser.UI.Win
{
    partial class FrmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.emieFileUploadControl1 = new EMIE.Parser.UI.Win.UserControls.EMIEFileUploadControl();
            this.duplicateListControl1 = new EMIE.Parser.UI.Win.UserControls.DuplicateListControl();
            this.domainListControl1 = new EMIE.Parser.UI.Win.UserControls.DomainListControl();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(161)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 50);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(32)))), ((int)(((byte)(49)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 78);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enterprise Discovery - Site List Export";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.domainListControl1);
            this.panel3.Controls.Add(this.emieFileUploadControl1);
            this.panel3.Controls.Add(this.duplicateListControl1);
            this.panel3.Location = new System.Drawing.Point(-2, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(996, 622);
            this.panel3.TabIndex = 5;
            // 
            // emieFileUploadControl1
            // 
            this.emieFileUploadControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emieFileUploadControl1.Location = new System.Drawing.Point(0, 0);
            this.emieFileUploadControl1.Name = "emieFileUploadControl1";
            this.emieFileUploadControl1.Size = new System.Drawing.Size(994, 620);
            this.emieFileUploadControl1.TabIndex = 0;
            this.emieFileUploadControl1.MoveNext += new EMIE.Parser.UI.Win.UserControls.BaseUserControl.NextEventHandler(this.emieFileUploadControl1_MoveNext);
            // 
            // duplicateListControl1
            // 
            this.duplicateListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.duplicateListControl1.Location = new System.Drawing.Point(0, 0);
            this.duplicateListControl1.Name = "duplicateListControl1";
            this.duplicateListControl1.Size = new System.Drawing.Size(994, 620);
            this.duplicateListControl1.TabIndex = 2;
            this.duplicateListControl1.Visible = false;
            this.duplicateListControl1.MoveNext += new EMIE.Parser.UI.Win.UserControls.BaseUserControl.NextEventHandler(this.duplicateListControl1_MoveNext);
            // 
            // domainListControl1
            // 
            this.domainListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.domainListControl1.Location = new System.Drawing.Point(0, 0);
            this.domainListControl1.Name = "domainListControl1";
            this.domainListControl1.Size = new System.Drawing.Size(994, 620);
            this.domainListControl1.TabIndex = 1;
            this.domainListControl1.Visible = false;
            this.domainListControl1.MoveNext += new EMIE.Parser.UI.Win.UserControls.BaseUserControl.NextEventHandler(this.domainListControl1_MoveNext);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(996, 730);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enterprise Site Discovery - Exportador";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.EMIEFileUploadControl emieFileUploadControl1;
        private UserControls.DomainListControl domainListControl1;
        private UserControls.DuplicateListControl duplicateListControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}