namespace SSBC_Mix
{
    partial class frmCPStation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtColorCode = new System.Windows.Forms.Label();
            this.txtMatName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMatCode = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblDescriptionBarcode = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageInput = new System.Windows.Forms.TabPage();
            this.TabPageHistory = new System.Windows.Forms.TabPage();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.colDel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLookUp = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnWareHouse = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TabPageInput.SuspendLayout();
            this.TabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Gray;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1031, 106);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "ĐÙN NHỰA";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Barcode :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Item : ";
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtItemName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(43, 147);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(755, 46);
            this.txtItemName.TabIndex = 11;
            this.txtItemName.Text = "txtItemName";
            this.txtItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtColor
            // 
            this.txtColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColor.BackColor = System.Drawing.Color.White;
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtColor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(250, 235);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(548, 46);
            this.txtColor.TabIndex = 14;
            this.txtColor.Text = "txtColor";
            this.txtColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Color :";
            // 
            // txtColorCode
            // 
            this.txtColorCode.BackColor = System.Drawing.Color.White;
            this.txtColorCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtColorCode.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorCode.Location = new System.Drawing.Point(41, 235);
            this.txtColorCode.Name = "txtColorCode";
            this.txtColorCode.Size = new System.Drawing.Size(203, 46);
            this.txtColorCode.TabIndex = 12;
            this.txtColorCode.Text = "txtColorCode";
            this.txtColorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMatName
            // 
            this.txtMatName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatName.BackColor = System.Drawing.Color.White;
            this.txtMatName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMatName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatName.Location = new System.Drawing.Point(251, 333);
            this.txtMatName.Name = "txtMatName";
            this.txtMatName.Size = new System.Drawing.Size(547, 46);
            this.txtMatName.TabIndex = 17;
            this.txtMatName.Text = "txtMatName";
            this.txtMatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 19);
            this.label11.TabIndex = 16;
            this.label11.Text = "Material :";
            // 
            // txtMatCode
            // 
            this.txtMatCode.BackColor = System.Drawing.Color.White;
            this.txtMatCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMatCode.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatCode.Location = new System.Drawing.Point(42, 333);
            this.txtMatCode.Name = "txtMatCode";
            this.txtMatCode.Size = new System.Drawing.Size(203, 46);
            this.txtMatCode.TabIndex = 15;
            this.txtMatCode.Text = "txtMatCode";
            this.txtMatCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWeight
            // 
            this.txtWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeight.BackColor = System.Drawing.Color.White;
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.ForeColor = System.Drawing.Color.Maroon;
            this.txtWeight.Location = new System.Drawing.Point(40, 416);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(758, 199);
            this.txtWeight.TabIndex = 18;
            this.txtWeight.Text = "txtWeight";
            this.txtWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(41, 37);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(757, 65);
            this.txtBarcode.TabIndex = 19;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // lblDescriptionBarcode
            // 
            this.lblDescriptionBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescriptionBarcode.BackColor = System.Drawing.Color.White;
            this.lblDescriptionBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescriptionBarcode.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionBarcode.Location = new System.Drawing.Point(12, 771);
            this.lblDescriptionBarcode.Name = "lblDescriptionBarcode";
            this.lblDescriptionBarcode.Size = new System.Drawing.Size(1007, 30);
            this.lblDescriptionBarcode.TabIndex = 21;
            this.lblDescriptionBarcode.Text = "Barcode : MI-XYZ-RU or MI-XYZ-DE";
            this.lblDescriptionBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.BackColor = System.Drawing.Color.Yellow;
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(3, 106);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1028, 30);
            this.lblMsg.TabIndex = 22;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.CausesValidation = false;
            this.tabControl1.Controls.Add(this.TabPageInput);
            this.tabControl1.Controls.Add(this.TabPageHistory);
            this.tabControl1.Location = new System.Drawing.Point(149, 139);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 629);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 24;
            // 
            // TabPageInput
            // 
            this.TabPageInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TabPageInput.Controls.Add(this.txtBarcode);
            this.TabPageInput.Controls.Add(this.label3);
            this.TabPageInput.Controls.Add(this.txtWeight);
            this.TabPageInput.Controls.Add(this.label1);
            this.TabPageInput.Controls.Add(this.txtMatName);
            this.TabPageInput.Controls.Add(this.txtItemName);
            this.TabPageInput.Controls.Add(this.label11);
            this.TabPageInput.Controls.Add(this.txtColorCode);
            this.TabPageInput.Controls.Add(this.txtMatCode);
            this.TabPageInput.Controls.Add(this.label8);
            this.TabPageInput.Controls.Add(this.txtColor);
            this.TabPageInput.Location = new System.Drawing.Point(4, 4);
            this.TabPageInput.Name = "TabPageInput";
            this.TabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageInput.Size = new System.Drawing.Size(843, 621);
            this.TabPageInput.TabIndex = 0;
            this.TabPageInput.Text = "...";
            this.TabPageInput.Click += new System.EventHandler(this.TabPageInput_Click);
            // 
            // TabPageHistory
            // 
            this.TabPageHistory.Controls.Add(this.dgvData);
            this.TabPageHistory.Location = new System.Drawing.Point(4, 4);
            this.TabPageHistory.Name = "TabPageHistory";
            this.TabPageHistory.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageHistory.Size = new System.Drawing.Size(789, 621);
            this.TabPageHistory.TabIndex = 1;
            this.TabPageHistory.Text = "...";
            this.TabPageHistory.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDel,
            this.colPrin});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 40;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.Size = new System.Drawing.Size(783, 615);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // colDel
            // 
            this.colDel.DataPropertyName = "btnDel";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.NullValue = "XÓA";
            this.colDel.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDel.HeaderText = "Xóa";
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            // 
            // colPrin
            // 
            this.colPrin.DataPropertyName = "btnPrint";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.NullValue = "IN TEM";
            this.colPrin.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrin.HeaderText = "In Tem";
            this.colPrin.Name = "colPrin";
            this.colPrin.ReadOnly = true;
            this.colPrin.Width = 150;
            // 
            // btnLookUp
            // 
            this.btnLookUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLookUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookUp.ForeColor = System.Drawing.Color.White;
            this.btnLookUp.Location = new System.Drawing.Point(10, 648);
            this.btnLookUp.Name = "btnLookUp";
            this.btnLookUp.Size = new System.Drawing.Size(130, 120);
            this.btnLookUp.TabIndex = 25;
            this.btnLookUp.Text = "Tìm Kiếm";
            this.btnLookUp.UseVisualStyleBackColor = false;
            this.btnLookUp.Click += new System.EventHandler(this.btnLookUp_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Teal;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(10, 140);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 120);
            this.btnStart.TabIndex = 27;
            this.btnStart.Text = "Đùn Nhựa";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnWareHouse
            // 
            this.btnWareHouse.BackColor = System.Drawing.Color.Navy;
            this.btnWareHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWareHouse.ForeColor = System.Drawing.Color.White;
            this.btnWareHouse.Location = new System.Drawing.Point(10, 267);
            this.btnWareHouse.Name = "btnWareHouse";
            this.btnWareHouse.Size = new System.Drawing.Size(130, 120);
            this.btnWareHouse.TabIndex = 28;
            this.btnWareHouse.Text = "Chuyển Kho";
            this.btnWareHouse.UseVisualStyleBackColor = false;
            this.btnWareHouse.Click += new System.EventHandler(this.btnWareHouse_Click);
            // 
            // frmCPStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 810);
            this.Controls.Add(this.btnWareHouse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLookUp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblDescriptionBarcode);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCPStation";
            this.Text = "frmCPStation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCPStation_FormClosing);
            this.Load += new System.EventHandler(this.frmCPStation_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabPageInput.ResumeLayout(false);
            this.TabPageInput.PerformLayout();
            this.TabPageHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtItemName;
        private System.Windows.Forms.Label txtColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtColorCode;
        private System.Windows.Forms.Label txtMatName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtMatCode;
        private System.Windows.Forms.Label txtWeight;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblDescriptionBarcode;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageHistory;
        private System.Windows.Forms.Button btnLookUp;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnWareHouse;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrin;
        private System.Windows.Forms.TabPage TabPageInput;
    }
}