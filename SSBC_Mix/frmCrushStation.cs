using DevExpress.XtraReports.UI;
using SerialPortListener.Serial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSBC_Mix
{
    public partial class frmCrushStation : Form
    {
        public frmCrushStation()
        {
            InitializeComponent();
            UserInitialization();
        }
        #region GetWeight
        SerialPortManager _spManager;

        string _Weight = "";
        // Handles the "Start Listening"-buttom click event


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

        string strData = "";
        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }



            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            strData = null;

            strData = Encoding.ASCII.GetString(e.Data);

            if (strData == "=")
            {
                   _Weight = null;
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
        #endregion

        


        private SSBC_Data.Extend.LowLevelKeyboardListener _listener;
        private ScannerInfo _ScannerInfo;
        private SSBC_Data.SourceContext dbContext;


        private void frmCrushStation_Load(object sender, EventArgs e)
        {
            WriteLog("Khởi động Mix");

            lblMsg.Visible = false;
            ////Kích Hoạt Cân
            //_listener = new SSBC_Data.Extend.LowLevelKeyboardListener();
            //_listener.OnKeyPressed += _listener_OnKeyPressed;
            //_listener.HookKeyboard();



            //Khởi tạo
            _ScannerInfo = new ScannerInfo();
            dbContext = new SSBC_Data.SourceContext();

            //Get Default Data
            //LoadDefaultData();
            //ListWinline = Data.Views.WinlineProductsItem.ItemsSource().ToList();


            

            //activeMIX();

        }
        private decimal WeightInput = 0;
        private int VoucherAfter = 0;




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
                    txtBarcode.Focus();

                    WriteLog("Error : Kiểm tra lại Barcode - " + txtBarcode.Text);

                    return;
                }

                //if (WeightInput == 0)
                //{
                //    lblMsg.Visible = true;
                //    lblMsg.Text = "Kiểm tra lại Số lượng";
                //    ReSetControl();
                //    txtBarcode.Focus();

                //    WriteLog("Error : Kiểm tra lại Số lượng - " + WeightInput.ToString());
                //    return;
                //}


                switch (TrackType)
                {
                    case "CRUSH":
                        scanCRUSH();
                        break;
                }


                if (_ScannerInfo.Msg == "")
                {
                    txtBarcode.Text = "";
                    
                    txtColorCode.Text = (_ScannerInfo.ColorCode).ToString();
                    txtColor.Text = _ScannerInfo.ColorName;
                    txtMatCode.Text = _ScannerInfo.MaterialCo;
                    txtMatName.Text = _ScannerInfo.MaterialName;

                    switch (TrackType)
                    {
                        case "CRUSH":
                            printCRUSH();
                            
                            break;
                      
                    }

                    
                    WriteLog("End : " + _ScannerInfo.TrackNo + ", " + _ScannerInfo.WinlineName + ", " + _ScannerInfo.ColorName + ", " + _ScannerInfo.MaterialName + ", " + _ScannerInfo.ScaleWeight.ToString());


                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = _ScannerInfo.Msg;

                    //===========
                    ReSetControl();
                    WriteLog("End with Error : " + _ScannerInfo.Msg);
                }



                //====

                // var ItemsSource = (List<SSBC_Mix.Data.SQLView.ViewStocks>)gvData.DataSource;
                txtBarcode.Focus();

            }
        }
        private void ReSetControl()
        {
            txtBarcode.Text = "";
            //txtBarcodeFull.Text = "";
            //txtTrackNo.Text = "";

           // txtWinlineCode.Text = "";
            
            txtColorCode.Text = "";
            txtColor.Text = "";
            txtMatCode.Text = "";
            txtMatName.Text = "";
            txtWeight.Text = "0";
        }



        private SSBC_Data.Extend.LabelTemplate MixLabel(string _LabelName, string _Barcode, decimal _ScaleWeight)
        {
            return new SSBC_Data.Extend.LabelTemplate
            {

                
                ItemName = _ScannerInfo.WinlineName,
                ColorCode = _ScannerInfo.ColorCode,
                ColorName = _ScannerInfo.ColorName,
                MaterialCo = _ScannerInfo.MaterialCo,
                MaterialName = _ScannerInfo.MaterialName,
                MaterialType = _ScannerInfo.MaterialType,
                ScaleWeight = _ScaleWeight,
                ScaleDate = _ScannerInfo.ScaleDate,
                LabelName = _LabelName,
                Barcode = _Barcode,
                BatchNo = _ScannerInfo.BatchNo.ToString(),
                MachineInfo = _ScannerInfo.MachineInfo


            };
        }






        #region Barcode Scanner

        void _listener_OnKeyPressed(object sender, SSBC_Data.Extend.KeyPressedArgs e)
        {
            //if (_FlagProcess == "Mixed-Add")
            {
               // txtBarcode.Focus();
            }


            //if (e.KeyPressed.ToString() != "Return")
            //{ this.txtWeight.Text += e.KeyPressed.ToString(); }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }
        #endregion

       

        #region GhiLog
        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "C:\\Logs\\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(DateTime.Now.ToString() + " " + strLog);
            log.Close();
        }
        #endregion



        private void frmCrushStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteLog("Đóng Phần Mềm Mix");
        }

    


        String TrackType = "";

        #region Button Click

        private void btnStart_Click(object sender, EventArgs e)
        {
            activeCRUSH();
        }
        

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            _spManager.StopListening();
            TrackType = "Lookup";

            lblStatus.Text = "Lịch Sử Dữ Liệu";

            tabControl1.SelectedTab = TabPageHistory;

            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_CrushTracks.Take(100).OrderByDescending(x => x.ScaleDate).ToList();
            foreach (var item in lst)
            {
                item.btnDel = "XÓA";
                item.btnPrint = "IN TEM";
            }
            
            dbContext.Dispose();

            dgvData.DataSource = lst;
            dgvData.Columns[2].Width = 130;
        }

        #endregion

        //Active
        private void activeCRUSH()
        {
            _spManager.StartListening();
            TrackType = "CRUSH";

            lblStatus.Text = "XAY NHỰA";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }
        
        //Scan
        private void scanCRUSH()
        {
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanCRUSH @Barcode,@ScaleWeight",Para_Barcode, Para_ScaleWeight).FirstOrDefault();

        }

    

        //Print
        private void printCRUSH()
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
                    LabelName = "CRUSH (XAY)",
                    Barcode = _ScannerInfo.TrackNo
                });


                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = "";

                Printer = _ScannerInfo.MaterialType == "CP" ? MyReader.GetValue("Printer_Yellow", typeof(string)).ToString() : MyReader.GetValue("Printer_White", typeof(string)).ToString();


                Report.rptLabelBarcode01 rep = new Report.rptLabelBarcode01();
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
        
      
        //Grid
        int rowindex = 0;
        int columnindex = 0;
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblStatus.Text = "XAY NHỰA";
            //tabControl1.SelectedTab = TabPageInput;



            rowindex = dgvData.CurrentCell.RowIndex;
            columnindex = dgvData.CurrentCell.ColumnIndex;

            dgvData.Rows[rowindex].Cells[columnindex].Value.ToString();



            if (dgvData.Rows[rowindex].Cells[columnindex].Value.ToString() == "IN TEM")
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();

                ListItem.Add(new SSBC_Data.Extend.LabelTemplate
                {

                    ItemName = dgvData.Rows[rowindex].Cells[3].Value.ToString(),
                    ColorCode = Decimal.Parse(dgvData.Rows[rowindex].Cells[4].Value.ToString()),
                    ColorName = dgvData.Rows[rowindex].Cells[5].Value.ToString(),
                    MaterialCo = dgvData.Rows[rowindex].Cells[6].Value.ToString(),
                    MaterialName = dgvData.Rows[rowindex].Cells[7].Value.ToString(),
                    MaterialType = "RE",
                    ScaleWeight = decimal.Parse(dgvData.Rows[rowindex].Cells[8].Value.ToString()),
                    ScaleDate = DateTime.Parse(dgvData.Rows[rowindex].Cells[2].Value.ToString()),
                    LabelName = "CRUSH (XAY)",
                    Barcode = dgvData.Rows[rowindex].Cells[9].Value.ToString(),
                    BatchNo = dgvData.Rows[rowindex].Cells[11].Value.ToString(),
                    MachineInfo = ""
                }
                );



                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = "";

                Printer = MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                //rep.ShowPreviewDialog();
                rep.Dispose();
                return;

            }

            if (dgvData.Rows[rowindex].Cells[columnindex].Value.ToString() == "XÓA")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?","Thông Báo",  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = "CRUSH" };
                    var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = dgvData.Rows[rowindex].Cells[9].Value.ToString() };
                    lblMsg.Visible = true;
                    lblMsg.Text = dbContext.Database.SqlQuery<string>("dbo.sp_SSBC_Delete_Trackings @TrackType,@Barcode", Para_Barcode, Para_TrackType).FirstOrDefault();
                }

                return;
            }


        }

    }
}
