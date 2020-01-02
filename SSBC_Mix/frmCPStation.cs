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
    public partial class frmCPStation : Form
    {
        public frmCPStation()
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


        private void frmCPStation_Load(object sender, EventArgs e)
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

            //
            _spManager.StartListening();
            TrackType = "COMPOUND";

            lblStatus.Text = "ĐÙN NHỰA";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();

            //Tạo ListView 



        }
        private decimal WeightInput = 0;
        private int VoucherAfter = 0;


        String TrackType = "";

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

                if (WeightInput == 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Kiểm tra lại Số lượng";
                    ReSetControl();
                    txtBarcode.Focus();

                    WriteLog("Error : Kiểm tra lại Số lượng - " + WeightInput.ToString());
                    return;
                }

                switch (TrackType)
                {
                    case "COMPOUND":
                        scanCOMPOUND();
                        break;
                    case "WHS":
                        scanWHS();
                        break;
                }
                

                if (_ScannerInfo.Msg == "")
                {
                    txtBarcode.Text = "";
                    txtItemName.Text = _ScannerInfo.WinlineName;
                    txtColorCode.Text = (_ScannerInfo.ColorCode).ToString();
                    txtColor.Text = _ScannerInfo.ColorName;
                    txtMatCode.Text = _ScannerInfo.MaterialCo;
                    txtMatName.Text = _ScannerInfo.MaterialName;

                    if (fBarcode.Substring(0, 2) == "PF")
                    {
                        PrintCOMPOUND();
                        
                    }
                    
                    else if (fBarcode.Substring(0, 2) == "CR")
                    {
                        PrintWHS();
                    }

                    
                    txtBarcode.Focus();
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

            //txtWinlineCode.Text = "";
            txtItemName.Text = "";
            txtColorCode.Text = "";
            txtColor.Text = "";
            txtMatCode.Text = "";
            txtMatName.Text = "";
            txtWeight.Text = "0";
        }


        private void scanCOMPOUND()
        {
            var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = TrackType };
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanCOMPOUND @TrackType,@Barcode,@ScaleWeight", Para_Barcode, Para_ScaleWeight, Para_TrackType).FirstOrDefault();
         

            
        }


        private void scanWHS()
        {
            
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanWHS @Barcode,@ScaleWeight", Para_Barcode, Para_ScaleWeight).FirstOrDefault();
          


        }

        #region In Tem




        #region PrintMIX

     

        private void PrintCOMPOUND()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();

                ListItem.Add(new SSBC_Data.Extend.LabelTemplate
                {

                    ItemName = _ScannerInfo.WinlineName,
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialName,
                    MaterialType = "CP",
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = "COMPOUND (ĐÙN)",
                    Barcode = _ScannerInfo.TrackNo,
                    BatchNo =_ScannerInfo.BatchNo.ToString(),
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
                rep.Dispose();
                //rep.ShowPreview();


            }
            catch (Exception err)
            {

            }
        }

        private void PrintWHS()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();

                ListItem.Add(new SSBC_Data.Extend.LabelTemplate
                {

                    ItemName = _ScannerInfo.WinlineName,
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialName,
                    MaterialType = "CP",
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = _ScannerInfo.MaterialType=="CP"? "ĐÙN - WAREHOUSE":"XAY - WAREHOUSE",
                    Barcode = _ScannerInfo.TrackNo,
                    BatchNo = _ScannerInfo.BatchNo.ToString(),
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
                rep.Dispose();
                //rep.ShowPreview();


            }
            catch (Exception err)
            {

            }
        }
        #endregion


        #region PrintProReturn
        private void PrintProReturn()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();



                ListItem.Add(
                new SSBC_Data.Extend.LabelTemplate
                {

                    //WinlineCode = _ScannerInfo.WinlineCo,
                    ItemName = _ScannerInfo.WinlineName,
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialName,
                    MaterialType = _ScannerInfo.MaterialType,
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = "Pro (Sản Xuất)",
                    Barcode = _ScannerInfo.TrackNo,
                    BatchNo = _ScannerInfo.BatchNo.ToString(),
                    MachineInfo = _ScannerInfo.MachineInfo


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

        #region PrintProReturnOut
        private void PrintProReturnOut()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();



                ListItem.Add(
                new SSBC_Data.Extend.LabelTemplate
                {

                    //WinlineCode = _ScannerInfo.WinlineCo,
                    ItemName = _ScannerInfo.WinlineName,
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialName,
                    MaterialType = _ScannerInfo.MaterialType,
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = "Pro-Out (Kho SX)",
                    Barcode = _ScannerInfo.TrackNo,
                    BatchNo = _ScannerInfo.BatchNo.ToString(),
                    MachineInfo = _ScannerInfo.MachineInfo


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
            log.WriteLine(DateTime.Now.ToString()+" " +strLog);
            log.Close();
        }

        private void frmCPStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteLog("Đóng Phần Mềm Mix");
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            ReSetControl();
            txtBarcode.Focus();
        }



       

        //Btn ĐÙN
        private void btnStart_Click(object sender, EventArgs e)
        {
            _spManager.StartListening();
            TrackType = "COMPOUND";

            lblStatus.Text = "ĐÙN NHỰA";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();

            
        }
        //Btn Chuyển qua kho
        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            _spManager.StartListening();
            TrackType = "WHS";

            lblStatus.Text = "Xuất Qua WareHouse";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();



        }
        //Btn Tìm Kiếm
        private void btnLookUp_Click(object sender, EventArgs e)
        {
            _spManager.StopListening();
            TrackType = "Lookup";

            lblStatus.Text = "Lịch Sử Dữ Liệu";

            tabControl1.SelectedTab = TabPageHistory;

            var dbContext = new SSBC_Data.SourceContext();
            var lst= dbContext.vSSBC_CompoundTracks.Take(100).OrderByDescending(x=>x.ScaleDate).ToList();
            foreach(var item in lst)
            {
                item.btnDel = "XÓA";
                item.btnPrint = "IN TEM";
            }

            dbContext.Dispose();

            dgvData.DataSource = lst;
        }


        int rowindex = 0;
        int columnindex = 0;
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblStatus.Text = "ĐÙN NHỰA";
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
                    MaterialType = "CP",
                    ScaleWeight = decimal.Parse(dgvData.Rows[rowindex].Cells[8].Value.ToString()),
                    ScaleDate = DateTime.Parse(dgvData.Rows[rowindex].Cells[2].Value.ToString()),
                    LabelName = "COMPOUND (ĐÙN)",
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
                if (MessageBox.Show("Thông Báo", "Bạn có chắc muốn xóa dòng này?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = "COMPOUND" };
                    var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = dgvData.Rows[rowindex].Cells[9].Value.ToString() };
                    lblMsg.Visible = true;
                    lblMsg.Text = dbContext.Database.SqlQuery<string>("dbo.sp_SSBC_Delete_Trackings @TrackType,@Barcode", Para_Barcode, Para_TrackType).FirstOrDefault();
                }

                return;
            }


        }

        private void TabPageInput_Click(object sender, EventArgs e)
        {

        }
    }
}
