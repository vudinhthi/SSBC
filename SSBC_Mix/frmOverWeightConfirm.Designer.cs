namespace SSBC_Mix
{
    partial class frmOverWeightConfirm
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
            this.chkOption01 = new System.Windows.Forms.CheckBox();
            this.chkOption02 = new System.Windows.Forms.CheckBox();
            this.chkOption03 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkOption01
            // 
            this.chkOption01.BackColor = System.Drawing.Color.White;
            this.chkOption01.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOption01.ForeColor = System.Drawing.Color.Black;
            this.chkOption01.Location = new System.Drawing.Point(19, 22);
            this.chkOption01.Name = "chkOption01";
            this.chkOption01.Size = new System.Drawing.Size(435, 53);
            this.chkOption01.TabIndex = 16;
            this.chkOption01.Text = "Tăng thêm số máy";
            this.chkOption01.UseVisualStyleBackColor = false;
            this.chkOption01.CheckedChanged += new System.EventHandler(this.chkOption01_CheckedChanged);
            // 
            // chkOption02
            // 
            this.chkOption02.BackColor = System.Drawing.Color.White;
            this.chkOption02.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOption02.ForeColor = System.Drawing.Color.Black;
            this.chkOption02.Location = new System.Drawing.Point(19, 84);
            this.chkOption02.Name = "chkOption02";
            this.chkOption02.Size = new System.Drawing.Size(435, 53);
            this.chkOption02.TabIndex = 17;
            this.chkOption02.Text = "Lặp lại đơn hàng";
            this.chkOption02.UseVisualStyleBackColor = false;
            this.chkOption02.CheckedChanged += new System.EventHandler(this.chkOption02_CheckedChanged);
            // 
            // chkOption03
            // 
            this.chkOption03.BackColor = System.Drawing.Color.White;
            this.chkOption03.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOption03.ForeColor = System.Drawing.Color.Black;
            this.chkOption03.Location = new System.Drawing.Point(19, 145);
            this.chkOption03.Name = "chkOption03";
            this.chkOption03.Size = new System.Drawing.Size(435, 53);
            this.chkOption03.TabIndex = 18;
            this.chkOption03.Text = "Lý do khác";
            this.chkOption03.UseVisualStyleBackColor = false;
            this.chkOption03.CheckedChanged += new System.EventHandler(this.chkOption03_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 57);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tổng số kí đã vượt công thức - bạn muốn cân thêm?”. ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(256, 72);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(118, 53);
            this.btnYes.TabIndex = 20;
            this.btnYes.Text = "Có";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Location = new System.Drawing.Point(141, 72);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(109, 53);
            this.btnNo.TabIndex = 21;
            this.btnNo.Text = "Không";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(162, 207);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(189, 53);
            this.btnConfirm.TabIndex = 22;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkOption03);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.chkOption01);
            this.groupBox1.Controls.Add(this.chkOption02);
            this.groupBox1.Location = new System.Drawing.Point(12, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 272);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // frmOverWeightConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(525, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOverWeightConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOverWeightConfirm";
            this.Load += new System.EventHandler(this.frmOverWeightConfirm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkOption01;
        private System.Windows.Forms.CheckBox chkOption02;
        private System.Windows.Forms.CheckBox chkOption03;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}