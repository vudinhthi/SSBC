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
    public partial class frmOverWeightConfirm : Form
    {
        public frmOverWeightConfirm()
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

      

       

        private void frmOverWeightConfirm_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                Option = "No";
                Reason = "";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {

            }
        }

        public string Reason = "";
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Option = "Yes";

                if(chkOption01.Checked==true)
                {
                    Reason += chkOption01.Text+",";
                }

                if (chkOption02.Checked == true)
                {
                    Reason += chkOption02.Text + ",";
                }

                if (chkOption03.Checked == true)
                {
                    Reason = chkOption03.Text;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {

            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void chkOption01_CheckedChanged(object sender, EventArgs e)
        {
            if(chkOption01.Checked==true || chkOption02.Checked==true)
            {
                chkOption03.Checked = false;
            }
        }

        private void chkOption02_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOption01.Checked == true || chkOption02.Checked == true)
            {
                chkOption03.Checked = false;
            }
        }

        private void chkOption03_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOption03.Checked == true)
            {
                chkOption01.Checked = false;
                chkOption02.Checked = false;
            }
        }
    }
}
