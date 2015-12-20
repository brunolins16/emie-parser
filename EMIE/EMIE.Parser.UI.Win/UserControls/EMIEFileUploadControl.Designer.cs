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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbCSV = new System.Windows.Forms.RadioButton();
            this.rdbXML = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // opdDiscoveryFile
            // 
            this.opdDiscoveryFile.FileName = "*.csv";
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
            this.label2.Size = new System.Drawing.Size(422, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Passo 1 -> Seleção de arquivo (CSV) de origem";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(832, 174);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(133, 39);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Próximo";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.txtFile.Location = new System.Drawing.Point(26, 134);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(860, 30);
            this.txtFile.TabIndex = 2;
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.btnUpload.Location = new System.Drawing.Point(892, 128);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(73, 40);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.label1.Location = new System.Drawing.Point(22, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o arquivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.label3.Location = new System.Drawing.Point(22, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de arquivo:";
            // 
            // rdbCSV
            // 
            this.rdbCSV.AutoSize = true;
            this.rdbCSV.Checked = true;
            this.rdbCSV.Location = new System.Drawing.Point(179, 63);
            this.rdbCSV.Name = "rdbCSV";
            this.rdbCSV.Size = new System.Drawing.Size(56, 21);
            this.rdbCSV.TabIndex = 7;
            this.rdbCSV.TabStop = true;
            this.rdbCSV.Tag = "0";
            this.rdbCSV.Text = "CSV";
            this.rdbCSV.UseVisualStyleBackColor = true;
            this.rdbCSV.CheckedChanged += new System.EventHandler(this.rdbType_CheckedChanged);
            // 
            // rdbXML
            // 
            this.rdbXML.AutoSize = true;
            this.rdbXML.Location = new System.Drawing.Point(241, 63);
            this.rdbXML.Name = "rdbXML";
            this.rdbXML.Size = new System.Drawing.Size(57, 21);
            this.rdbXML.TabIndex = 8;
            this.rdbXML.Tag = "1";
            this.rdbXML.Text = "XML";
            this.rdbXML.UseVisualStyleBackColor = true;
            this.rdbXML.CheckedChanged += new System.EventHandler(this.rdbType_CheckedChanged);
            // 
            // EMIEFileUploadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdbXML);
            this.Controls.Add(this.rdbCSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label1);
            this.Name = "EMIEFileUploadControl";
            this.Size = new System.Drawing.Size(990, 297);
            this.Load += new System.EventHandler(this.EMIEFileUploadControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opdDiscoveryFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbCSV;
        private System.Windows.Forms.RadioButton rdbXML;
    }
}
