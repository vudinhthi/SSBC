using DevExpress.XtraReports.UI;
using SerialPortListener.Serial;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSBC_Mix
{
    public partial class frmRedStation : Form
    {
        public frmRedStation()
        {
            InitializeComponent();
            UserInitialization();
        }

        #region GetWeight

        private SerialPortManager _spManager;

        private string _Weight = "";

        // Handles the "Start Listening"-buttom click event
        private void btnStart_Click(object sender, EventArgs e)
        {
            _spManager.StartListening();
        }

        // Handles the "Stop Listening"-buttom click event
        private void btnStop_Click(object sender, EventArgs e)
        {
            _spManager.StopListening();
        }

        private void UserInitialization()
        {
            var MyReader = new System.Configuration.AppSettingsReader();

            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;

            mySerialSettings.PortName = MyReader.GetValue("PortName", typeof(string)).ToString();

            mySerialSettings.BaudRate = int.Parse(MyReader.GetValue("BaudRate", typeof(string)).ToString());
            mySerialSettings.DataBits = 8;
            mySerialSettings.Parity = 0;
            mySerialSettings.StopBits = StopBits.One;

            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _spManager.Dispose();
        }

        private string strData = "";

        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            strData = Encoding.ASCII.GetString(e.Data);

            if (strData == "=")
            {
                _Weight = "";
            }

            if (strData != "B" && strData != "C" && strData != "=")
            {
                _Weight = _Weight + strData;
            }

            if (strData == "B" || strData == "C")
            {
                txtWeight.Text = _Weight.Trim();
            }
        }

        #endregion GetWeight

        private SSBC_Data.Extend.LowLevelKeyboardListener _listener;
        private ScannerInfo _ScannerInfo;
        private SSBC_Data.SourceContext dbContext;

        private void frmRedStation_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            //Kích Hoạt Cân
            _listener = new SSBC_Data.Extend.LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();

            //Khởi tạo
            _ScannerInfo = new ScannerInfo();
            dbContext = new SSBC_Data.SourceContext();

            //Get Default Data
            //LoadDefaultData();
            //ListWinline = Data.Views.WinlineProductsItem.ItemsSource().ToList();

            ReSetControl();
            //Load Winline Product
            _spManager.StartListening();
        }

        private decimal WeightInput = 0;

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMsg.Text = "";
                lblMsg.Visible = false;

                var fBarcode = txtBarcode.Text;
                WeightInput = decimal.Parse(txtWeight.Text);

                //Kiểm tra tự động chuyển

                if (txtBarcode.Text.Length < 3)
                {
                    lblMsg.Text = "Kiểm tra lại Barcode";
                    lblMsg.Visible = true;
                    ReSetControl();
                }
                else if (WeightInput == 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Kiểm tra lại Số lượng";
                    ReSetControl();
                }
                else
                {
                    var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = fBarcode };
                    var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };

                    _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_RedStation_GetData @Barcode,@ScaleWeight", Para_Barcode, Para_ScaleWeight).FirstOrDefault();

                    if (_ScannerInfo.Msg == "")
                    {
                        txtBarcode.Text = "";
                        txtBarcodeFull.Text = fBarcode;
                        txtTrackNo.Text = _ScannerInfo.TrackNo;
                        txtColorCode.Text = (_ScannerInfo.ColorCode).ToString();
                        txtColor.Text = _ScannerInfo.ColorName;
                        txtMatCode.Text = _ScannerInfo.MaterialCo;
                        txtMatName.Text = _ScannerInfo.MaterialCo;

                        Print();

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

                //====

                // var ItemsSource = (List<SSBC_Mix.Data.SQLView.ViewStocks>)gvData.DataSource;
            }
        }

        private void ReSetControl()
        {
            txtBarcode.Text = "";
            txtBarcodeFull.Text = "";
            txtTrackNo.Text = "";
            txtColorCode.Text = "";
            txtColor.Text = "";
            txtMatCode.Text = "";
            txtMatName.Text = "";
            txtWeight.Text = "0";
        }

        #region In Tem

        #region PrintMIX

        private void Print()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();

                ListItem.Add(
                new SSBC_Data.Extend.LabelTemplate
                {
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialCo,
                    MaterialType = _ScannerInfo.MaterialType,
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = "RED (PHẾ)",
                    Barcode = _ScannerInfo.TrackNo
                });

                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = "";

                Printer = _ScannerInfo.MaterialType == "CP" ? MyReader.GetValue("Printer_Yellow", typeof(string)).ToString() : MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode01 rep = new Report.rptLabelBarcode01();
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                //rep.ShowPreview();
            }
            catch (Exception err)
            {
            }
        }

        #endregion PrintMIX

        #endregion In Tem

        #region Barcode Scanner

        private void _listener_OnKeyPressed(object sender, SSBC_Data.Extend.KeyPressedArgs e)
        {
            //if (_FlagProcess == "Mixed-Add")
            {
                //txtBarcode.Focus();
            }

            //if (e.KeyPressed.ToString() != "Return")
            //{ this.txtWeight.Text += e.KeyPressed.ToString(); }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        #endregion Barcode Scanner

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}