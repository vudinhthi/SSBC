using DevExpress.XtraReports.UI;
using SerialPortListener.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSBC_Mix
{
    public partial class frmCopyStation : Form
    {
        public frmCopyStation()
        {
            InitializeComponent();
            
        }
        

        


        private SSBC_Data.Extend.LowLevelKeyboardListener _listener;
        private ScannerInfo _ScannerInfo;
        private SSBC_Data.SourceContext dbContext;


        private void frmCopyStation_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            //Kích Hoạt Cân
            //_listener = new SSBC_Data.Extend.LowLevelKeyboardListener();
            //_listener.OnKeyPressed += _listener_OnKeyPressed;
            //_listener.HookKeyboard();

            

            //Khởi tạo
            _ScannerInfo = new ScannerInfo();
            dbContext = new SSBC_Data.SourceContext();

            //Get Default Data
            //LoadDefaultData();
            //ListWinline = Data.Views.WinlineProductsItem.ItemsSource().ToList();


            ReSetControl();
            //Load Winline Product
            

        }
        


        


        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMsg.Text = "";
                lblMsg.Visible = false;

                var fBarcode = txtBarcode.Text;


                //Kiểm tra tự động chuyển


                var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = fBarcode };
                


                _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_Station_CopyLabel @Barcode", Para_Barcode).FirstOrDefault();

                if (_ScannerInfo.Msg == "")
                {
                    txtBarcode.Text = "";
                    txtBarcodeFull.Text = fBarcode;
                    txtTrackNo.Text = _ScannerInfo.TrackNo;
                    //txtWinlineCode.Text = _ScannerInfo.WinlineCo;
                    txtItemName.Text = _ScannerInfo.WinlineName;
                    txtColorCode.Text = (_ScannerInfo.ColorCode).ToString();
                    txtColor.Text = _ScannerInfo.ColorName;
                    txtMatCode.Text = _ScannerInfo.MaterialCo;
                    txtMatName.Text = _ScannerInfo.MaterialCo;

                    PrintMIX();

                    txtBarcode.Focus();

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = _ScannerInfo.Msg;

                    //===========
                    ReSetControl();
                }


            }
        }
        private void ReSetControl()
        {
            txtBarcode.Text = "";
            txtBarcodeFull.Text = "";
            txtTrackNo.Text = "";

            txtWinlineCode.Text = "";
            txtItemName.Text = "";
            txtColorCode.Text = "";
            txtColor.Text = "";
            txtMatCode.Text = "";
            txtMatName.Text = "";
            txtWeight.Text = "0";
        }


       

     




        



        #region In Tem

    


        #region PrintMIX
        private void PrintMIX()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();
                string LabelName = "";

                if(_ScannerInfo.TrackNo.Substring(0, 2)=="MI")
                {
                    if (txtBarcodeFull.Text.Split('-')[1]=="MI")
                    {
                        LabelName = "Copy Mix (Trộn)";
                    }
                    else if (txtBarcodeFull.Text.Split('-')[1] == "RU")
                    {
                    }
                    else if (txtBarcodeFull.Text.Split('-')[1] == "DE")
                    {
                        LabelName = "Copy Defect (Phế)";
                    }
                    else if (txtBarcodeFull.Text.Split('-')[1] == "RE")
                    {
                        LabelName = "Copy Red (Chấm Đen)";
                    }
                }
           



                ListItem.Add(
                new SSBC_Data.Extend.LabelTemplate
                {

                    //winlineCode = _ScannerInfo.WinlineCo,
                    ItemName = _ScannerInfo.WinlineName,
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialCo,
                    MaterialType = _ScannerInfo.MaterialType,
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = LabelName,
                    Barcode = _ScannerInfo.TrackNo + "-"+txtBarcodeFull.Text.Substring(_ScannerInfo.TrackNo.Length+1,2),
                    BatchNo = _ScannerInfo.BatchNo.ToString()

                });

                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = "";

                Printer = MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();


            }
            catch (Exception err)
            {

            }
        }
        #endregion


    

        




        #endregion






        #region Barcode Scanner

        void _listener_OnKeyPressed(object sender, SSBC_Data.Extend.KeyPressedArgs e)
        {
            //if (_FlagProcess == "Mixed-Add")
            {
                txtBarcode.Focus();
            }


            //if (e.KeyPressed.ToString() != "Return")
            //{ this.txtWeight.Text += e.KeyPressed.ToString(); }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string txt = "A-a";
            lblMsg.Text = txt.Split('-').Length.ToString();
            lblMsg.Visible = true;
        }
    }
}
