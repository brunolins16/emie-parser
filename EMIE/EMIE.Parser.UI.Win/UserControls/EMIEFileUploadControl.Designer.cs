namespace EMIE.Parser.UI.Win.UserControls
{
    partial class EMIEFileUploadControl
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
            this.opdDiscoveryFile = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFileList = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opdDiscoveryFile
            // 
            this.opdDiscoveryFile.Multiselect = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 47);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(161)))));
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Passo 1 -> Seleção de arquivos de origem";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(832, 517);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(133, 39);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Próximo";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.btnUpload.Location = new System.Drawing.Point(191, 54);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(73, 32);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.label1.Location = new System.Drawing.Point(22, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o arquivo:";
            // 
            // pnlFileList
            // 
            this.pnlFileList.AutoScroll = true;
            this.pnlFileList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlFileList.Location = new System.Drawing.Point(26, 119);
            this.pnlFileList.Name = "pnlFileList";
            this.pnlFileList.Size = new System.Drawing.Size(939, 394);
            this.pnlFileList.TabIndex = 9;
            this.pnlFileList.WrapContents = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.label4.Location = new System.Drawing.Point(22, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Arquivos selecionados:";
            // 
            // EMIEFileUploadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlFileList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label1);
            this.Name = "EMIEFileUploadControl";
            this.Size = new System.Drawing.Size(990, 559);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opdDiscoveryFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlFileList;
        private System.Windows.Forms.Label label4;
    }
}
