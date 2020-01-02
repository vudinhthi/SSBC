using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSBC_Mix
{
    public partial class frmMixPopUp : Form
    {
        public frmMixPopUp()
        {
            InitializeComponent();
        }
        public string Option = "";
        public string VoucherID = "";
        private void btnOption01_Click(object sender, EventArgs e)
        {
            try
            {
                Option = "ReturnProd";
                VoucherID = "0";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {

            }
        }

       

        private void btnOption02_Click(object sender, EventArgs e)
        {
            try
            {
                Option = "Mix";
                if(VoucherID=="" || VoucherID == "0")
                {
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {

            }
        }

      

       

        private void frmMixPopUp_Load(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "0";
            txtVoucherID.Text = VoucherID;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "1";
            txtVoucherID.Text = VoucherID;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "2";
            txtVoucherID.Text = VoucherID;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "3";
            txtVoucherID.Text = VoucherID;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "4";
            txtVoucherID.Text = VoucherID;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "5";
            txtVoucherID.Text = VoucherID;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "6";
            txtVoucherID.Text = VoucherID;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "7";
            txtVoucherID.Text = VoucherID;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "8";
            txtVoucherID.Text = VoucherID;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            VoucherID = VoucherID + "9";
            txtVoucherID.Text = VoucherID;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            VoucherID = "";
            txtVoucherID.Text = VoucherID;
        }
    }
}
