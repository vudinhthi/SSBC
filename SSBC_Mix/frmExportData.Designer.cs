namespace SSBC_Mix
{
    partial class frmExportData
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.rdMix = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdCrush = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(22, 63);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(121, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến Ngày";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(166, 63);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(121, 20);
            this.dtTo.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(23, 201);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(264, 45);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(23, 104);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(264, 20);
            this.txtUrl.TabIndex = 6;
            this.txtUrl.Text = "D:\\DataExport\\Test.xlsx";
            // 
            // rdMix
            // 
            this.rdMix.AutoSize = true;
            this.rdMix.Location = new System.Drawing.Point(62, 16);
            this.rdMix.Name = "rdMix";
            this.rdMix.Size = new System.Drawing.Size(47, 17);
            this.rdMix.TabIndex = 7;
            this.rdMix.TabStop = true;
            this.rdMix.Text = "Trộn";
            this.rdMix.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdCrush);
            this.groupBox1.Controls.Add(this.rdMix);
            this.groupBox1.Location = new System.Drawing.Point(23, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 44);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy Chọn";
            // 
            // rdCrush
            // 
            this.rdCrush.AutoSize = true;
            this.rdCrush.Location = new System.Drawing.Point(143, 16);
            this.rdCrush.Name = "rdCrush";
            this.rdCrush.Size = new System.Drawing.Size(43, 17);
            this.rdCrush.TabIndex = 8;
            this.rdCrush.TabStop = true;
            this.rdCrush.Text = "Xay";
            this.rdCrush.UseVisualStyleBackColor = true;
            // 
            // frmExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 258);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExportData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportData";
            this.Load += new System.EventHandler(this.frmExportData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.RadioButton rdMix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdCrush;
    }
}