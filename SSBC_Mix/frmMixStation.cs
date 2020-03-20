using DevExpress.XtraReports.UI;
using SerialPortListener.Serial;
using SSBC_Data.SQLext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace SSBC_Mix
{
    public partial class frmMixStation : Form
    {
        /// <summary>
        /// frmMixStation
        /// </summary>
        public frmMixStation()
        {
            InitializeComponent();
            UserInitialization();
        }

        #region GetWeight

        private SerialPortManager _spManager;

        private string _Weight = string.Empty;
        // Handles the "Start Listening"-buttom click event

        /// <summary>
        /// Handles the "Stop Listening"-buttom click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            _spManager.StopListening();
        }

        /// <summary>
        /// UserInitialization
        /// </summary>
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

        /// <summary>
        /// MainForm_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _spManager.Dispose();
        }

        private string strData = string.Empty;

        /// <summary>
        /// _spManager_NewSerialDataRecieved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            strData = null;

            strData = Encoding.ASCII.GetString(e.Data).Trim();

            if (strData == "=")
            {
                _Weight = null;
                _Weight = string.Empty;
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
        private string TrackType = string.Empty;

        //Grid
        private int rowIndex = 0;

        private int columnIndex = 0;

        private decimal WeightInput = 0;
        private int VoucherAfter = 0;
        private int SleepTime = 0;

        private string notifi = string.Empty;

        #region Pagging

        private int pageNumber = 1;
        private int numRecord = 15;

        private List<vSSBC_MixTracks> LoadRecord(int page, int recordNum)
        {
            List<vSSBC_MixTracks> result = new List<vSSBC_MixTracks>();
            //Skip
            result = dbContext.vSSBC_MixTracks.OrderByDescending(x => x.ScaleDate).Skip(page * recordNum).Take(numRecord).ToList();
            //Take

            return result;
        }

        #endregion Pagging

        /// <summary>
        /// frmMixStation_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMixStation_Load(object sender, EventArgs e)
        {
            WriteLog("Khởi động Mix");

            lblMsg.Visible = false;
            ////Kích Hoạt Cân
            _listener = new SSBC_Data.Extend.LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();

            //Khởi tạo
            _ScannerInfo = new ScannerInfo();
            dbContext = new SSBC_Data.SourceContext();

            //Get Default Data
            //LoadDefaultData();
            //ListWinline = Data.Views.WinlineProductsItem.ItemsSource().ToList();

            ACTIVEMIX();

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            //Time
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += TimerTick;
        }

        /// <summary>
        /// TimerTick
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void TimerTick(Object obj, ElapsedEventArgs e)
        {
            MessageBox.Show("Exiting");
            WriteLog("Exiting");
            Environment.Exit(0);
        }

        /// <summary>
        /// _listener_OnKeyPressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _listener_OnKeyPressed(object sender, SSBC_Data.Extend.KeyPressedArgs e)
        {
            if (e.KeyPressed.ToString() == "Return")
            {
                txtBarcode.Focus();
            }

            //if (e.KeyPressed.ToString() != "Return")
            //{ this.txtWeight.Text += e.KeyPressed.ToString(); }
        }

        /// <summary>
        /// Window_Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        /// <summary>
        /// txtBarcode_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lblMsg.Text = string.Empty;
                lblMsg.Visible = false;

                var fBarcode = txtBarcode.Text;
                WeightInput = decimal.Parse(txtWeight.Text);
                //WeightInput = 150;

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

                if (WeightInput == 0 && TrackType != "COPY")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Kiểm tra lại Số lượng";
                    ReSetControl();
                    txtBarcode.Focus();
                    MessageBox.Show("Error : Kiểm tra lại Số lượng - " + WeightInput.ToString());
                    WriteLog("Error : Kiểm tra lại Số lượng - " + WeightInput.ToString());
                    return;
                }
                switch (TrackType)
                {
                    case "MIX":
                        SCANMIX();
                        break;

                    case "WHS":
                        SCANWHS();
                        break;

                    case "RETURN":
                        SCANRETURN();
                        break;

                    case "RETURN-OUT":
                        SCANRETURNOUT();
                        break;

                    case "CRUSH":
                        SCANCRUSH();
                        break;

                    case "COMPOUND":
                        SCANCOMPOUND();
                        break;

                    case "RED":
                        SCANRED();
                        break;

                    case "COPY":
                        SCANCOPY();
                        break;
                }

                if (_ScannerInfo.Msg == string.Empty)
                {
                    txtBarcode.Text = string.Empty;
                    txtItemName.Text = _ScannerInfo.WinlineName;
                    txtColorCode.Text = (_ScannerInfo.ColorCode).ToString();
                    txtColor.Text = _ScannerInfo.ColorName;
                    txtMatCode.Text = _ScannerInfo.MaterialCo;
                    txtMatName.Text = _ScannerInfo.MaterialName;

                    switch (TrackType)
                    {
                        case "MIX":
                            PRINTMIX();
                            break;

                        case "WHS":
                            PRINTWHS();
                            break;

                        case "RETURN":
                            PRINTRETURN();
                            break;

                        case "RETURN-OUT":
                            PRINTRETURNOUT();
                            break;

                        case "CRUSH":
                            PRINTCRUSH();
                            break;

                        case "COMPOUND":
                            PRINTCOMPOUND();
                            break;

                        case "RED":
                            PRINTRED();
                            break;

                        case "COPY":
                            PRINTCOPY();
                            break;
                    }
                    SleepTime = 10;
                    lblSleepTime.Visible = true;
                    while (SleepTime > 0)
                    {
                        SleepTime -= 1;
                        lblSleepTime.Text = "Chờ " + SleepTime.ToString() + " giây";
                    }
                    lblSleepTime.Visible = false;
                    WriteLog("End : " + _ScannerInfo.TrackNo + ", " + _ScannerInfo.WinlineName + ", " + _ScannerInfo.ColorName + ", " + _ScannerInfo.MaterialName + ", " + _ScannerInfo.ScaleWeight.ToString());
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = _ScannerInfo.Msg;

                    //===========
                    ReSetControl();
                    MessageBox.Show("End with Error : " + _ScannerInfo.Msg);
                    WriteLog("End with Error : " + _ScannerInfo.Msg);
                }
                // var ItemsSource = (List<SSBC_Mix.Data.SQLView.ViewStocks>)gvData.DataSource;
                txtBarcode.Focus();
            }
        }

        /// <summary>
        /// ReSetControl
        /// </summary>
        private void ReSetControl()
        {
            //txtBarcodeFull.Text  = string.Empty;
            //txtTrackNo.Text      = string.Empty;
            // txtWinlineCode.Text = string.Empty;

            txtBarcode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtColorCode.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtMatCode.Text = string.Empty;
            txtMatName.Text = string.Empty;
            txtWeight.Text = 0.ToString();
        }

        private SSBC_Data.Extend.LabelTemplate MixLabel(string _LabelName, string _Barcode, decimal _ScaleWeight)
        {
            return new SSBC_Data.Extend.LabelTemplate
            {
                //WinlineCode = _ScannerInfo.WinlineCo,
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

        /// <summary>
        /// frmMixStation_FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMixStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                WriteLog("Đóng Phần Mềm Mix");
            }
        }

        #region Button Click

        /// <summary>
        /// Click TRỘN NHỰA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            ACTIVEMIX();
        }

        /// <summary>
        /// CLICK THU HỒI NHỰA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            ACTIVERETURN();
        }

        /// <summary>
        /// CLICK XUẤT NHỰA THU HỒI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnOut_Click(object sender, EventArgs e)
        {
            ACTIVERETURNOUT();
        }

        /// <summary>
        ///CLICK XUẤT QUA KHO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            ACTIVEWHS();
        }

        /// <summary>
        /// CLICK ĐÙN NHỰA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompound_Click(object sender, EventArgs e)
        {
            ACTIVECOMPOUND();
        }

        /// <summary>
        ///CLICK XÂY NHỰA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrush_Click(object sender, EventArgs e)
        {
            ACTIVECRUSH();
        }

        /// <summary>
        ///CLICK COPPY ITEM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                ACTIVECOPY();
                MessageBox.Show("Đã coppy table thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình coppy table !");
                ex.ToString();
            }
        }

        /// <summary>
        ///CLICK CHẤM ĐEN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRed_Click(object sender, EventArgs e)
        {
            ACTIVERED();
        }

        private void btnLookUp_Click(object sender, EventArgs e)
        {
            _spManager.StopListening();
            //TrackType = "Lookup";
            //lblStatus.Text = "Lịch Sử Dữ Liệu";

            tabControl1.SelectedTab = TabPageHistory;
            switch (TrackType)
            {
                case "MIX":
                    LOOKUPMIX();
                    break;

                case "WHS":
                    LOOKUPWHS();
                    break;

                case "RETURN":
                    LOOKUPRETURN();
                    break;

                case "RETURN-OUT":
                    LOOKUPRETURNOUT();
                    break;

                case "CRUSH":
                    LOOKUPCRUSH();
                    break;

                case "COMPOUND":
                    LOOKUPCOMPOUND();
                    break;

                case "RED":
                    LOOKUPRED();
                    break;
            }

            //var lst = dbContext.vSSBC_MixTrackinDays.OrderByDescending(x => x.ScaleDate).ToList();
            dgvData.Columns[2].Width = 130;
        }

        #endregion Button Click

        /// <summary>
        /// LOOKUPMIX SEARCH TRỘN NHỰA
        /// </summary>
        private void LOOKUPMIX()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_MixTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            foreach (var item in lst)
            {
                item.btnDel = "XÓA";
                item.btnPrint = "IN TEM";
            }
            dgvData.DataSource = lst;
            //dgvData.DataSource = LoadRecord(pageNumber,numRecord);//DataSource Dùng Phân Trang
            dbContext.Dispose();
        }

        /// <summary>
        /// LOOKUPRETURN SEARCH THU HỒI NHỰA
        /// </summary>
        private void LOOKUPRETURN()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_ProReturnTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    item.btnDel = "XÓA";
                    item.btnPrint = "IN TEM";
                }
                dgvData.DataSource = lst;
                dbContext.Dispose();
            }
        }

        /// <summary>
        /// LOOKUPRETURNOUT
        /// </summary>
        private void LOOKUPRETURNOUT()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_ProReturnOutTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            foreach (var item in lst)
            {
                item.btnDel = "XÓA";
                item.btnPrint = "IN TEM";
            }
            dgvData.DataSource = lst;
            dbContext.Dispose();
        }

        /// <summary>
        /// LOOKUPWHS SEARCH CHUYỂN KHO
        /// </summary>
        private void LOOKUPWHS()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_WhsTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    item.btnDel = "XÓA";
                    item.btnPrint = "IN TEM";
                }
                dgvData.DataSource = lst;
                dbContext.Dispose();
            }
        }

        /// <summary>
        /// LOOKUPCOMPOUND SEARCH ĐÙN NHỰA
        /// </summary>
        private void LOOKUPCOMPOUND()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_CompoundTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            if (lst.Count > 0)
            {
                foreach (var item in lst)
                {
                    item.btnDel = "XÓA";
                    item.btnPrint = "IN TEM";
                }
                dgvData.DataSource = lst;
                dbContext.Dispose();
            }
        }

        /// <summary>
        /// LOOKUPCRUSH SEARCH XÂY NHỰA
        /// </summary>
        private void LOOKUPCRUSH()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_CrushTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            foreach (var item in lst)
            {
                item.btnDel = "XÓA";
                item.btnPrint = "IN TEM";
            }
            dgvData.DataSource = lst;
            dbContext.Dispose();
        }

        /// <summary>
        /// LOOKUPRED SEARCH CHẤM ĐEN
        /// </summary>
        private void LOOKUPRED()
        {
            var dbContext = new SSBC_Data.SourceContext();
            var lst = dbContext.vSSBC_RedTracks.Take(100).OrderByDescending(x => x.ScaleDate).AsQueryable().ToList();
            foreach (var item in lst)
            {
                item.btnDel = "XÓA";
                item.btnPrint = "IN TEM";
            }
            dgvData.DataSource = lst;
            dbContext.Dispose();
        }

        /// <summary>
        /// ACTIVEMIX KHỞI CHẠY PROJECT VÀO TRỘN NHỰA
        /// </summary>
        private void ACTIVEMIX()
        {
            _spManager.StartListening();
            TrackType = "MIX";

            lblStatus.Text = "TRỘN NHỰA";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVERETURN THU HỒI NHỰA
        /// </summary>
        private void ACTIVERETURN()
        {
            _spManager.StartListening();
            TrackType = "RETURN";

            lblStatus.Text = "Nhựa Thu Hồi";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVERETURNOUT CLICK XUẤT NHỰA THU HỒI
        /// </summary>
        private void ACTIVERETURNOUT()
        {
            _spManager.StartListening();
            TrackType = "RETURN-OUT";

            lblStatus.Text = "Xuất Nhựa Thu Hồi";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVEWHS XUẤT QUA KHO
        /// </summary>
        private void ACTIVEWHS()
        {
            _spManager.StartListening();
            TrackType = "WHS";

            lblStatus.Text = "Xuất Qua WareHouse";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVECOMPOUND ĐÙN NHỰA
        /// </summary>
        private void ACTIVECOMPOUND()
        {
            _spManager.StartListening();
            TrackType = "COMPOUND";

            lblStatus.Text = "ĐÙN NHỰA";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVECRUSH XÂY NHỰA
        /// </summary>
        private void ACTIVECRUSH()
        {
            _spManager.StartListening();
            TrackType = "CRUSH";

            lblStatus.Text = "XAY NHỰA";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVERED CHẤM ĐEN
        /// </summary>
        private void ACTIVERED()
        {
            _spManager.StartListening();
            TrackType = "RED";

            lblStatus.Text = "CHẤM ĐEN";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// ACTIVECOPY COPPY ITEM
        /// </summary>
        private void ACTIVECOPY()
        {
            _spManager.StartListening();
            TrackType = "COPY";

            lblStatus.Text = "Copy Tem";
            tabControl1.SelectedTab = TabPageInput;

            ReSetControl();
            txtBarcode.Focus();
        }

        /// <summary>
        /// CheckOverWeight
        /// </summary>
        /// <returns></returns>
        private string CheckOverWeight()
        {
            var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = TrackType };
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            return dbContext.Database.SqlQuery<string>("dbo.sp_checkOverWeight @TrackType,@Barcode,@ScaleWeight", Para_TrackType, Para_Barcode, Para_ScaleWeight).FirstOrDefault();
        }

        /// <summary>
        /// SCANMIX
        /// </summary>
        private void SCANMIX()
        {
            string _Option = string.Empty, _Reason = string.Empty;
            if (CheckOverWeight() == "OverWeight")
            {
                using (var f = new frmOverWeightConfirm())
                {
                    var result = f.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        _Option = f.Option;
                        _Reason = f.Reason;
                    }
                }
            }

            if (_Option == "No")
            {
                _ScannerInfo = new ScannerInfo { Msg = "Vượt quá tổng khối lượng trên phiếu Trộn." };
                return;
            }

            var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = TrackType };
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            var Para_Reason = new SqlParameter { ParameterName = "Reason", Value = _Reason };

            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanMix @TrackType,@Barcode,@ScaleWeight,@Reason",
                            Para_TrackType, Para_Barcode,
                            Para_ScaleWeight, Para_Reason).FirstOrDefault();
        }

        /// <summary>
        /// SCANRETURN
        /// </summary>
        private void SCANRETURN()
        {
            var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = "RETURN" };
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanProReturn @TrackType,@Barcode,@ScaleWeight", Para_TrackType, Para_Barcode, Para_ScaleWeight).FirstOrDefault();
        }

        /// <summary>
        /// SCANRETURNOUT
        /// </summary>
        private void SCANRETURNOUT()
        {
            var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = "RETURN-OUT" };
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };

            if (txtBarcode.Text.Substring(0, 2) == "RE") //Xuất nhựa trả về
            {
                using (var f = new frmMixPopUp())
                {
                    var result = f.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        VoucherAfter = int.Parse(f.VoucherID);
                    }
                }
            }

            var Para_voucherAfter = new SqlParameter { ParameterName = "voucherAfter", Value = VoucherAfter };

            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanProReturnOut @TrackType,@Barcode,@ScaleWeight,@voucherAfter", Para_TrackType, Para_Barcode, Para_ScaleWeight, Para_voucherAfter).FirstOrDefault();
        }

        /// <summary>
        /// SCANWHS
        /// </summary>
        private void SCANWHS()
        {
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanWHS @Barcode,@ScaleWeight", Para_Barcode, Para_ScaleWeight).FirstOrDefault();
        }

        /// <summary>
        /// SCANCOMPOUND
        /// </summary>
        private void SCANCOMPOUND()
        {
            var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = "COMPOUND" };
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanCOMPOUND @TrackType,@Barcode,@ScaleWeight", Para_TrackType, Para_Barcode, Para_ScaleWeight).FirstOrDefault();
        }

        /// <summary>
        /// SCANCRUSH
        /// </summary>
        private void SCANCRUSH()
        {
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanCRUSH @Barcode,@ScaleWeight", Para_Barcode, Para_ScaleWeight).FirstOrDefault();
        }

        /// <summary>
        /// SCANRED
        /// </summary>
        private void SCANRED()
        {
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            var Para_ScaleWeight = new SqlParameter { ParameterName = "ScaleWeight", Value = WeightInput };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanRED @Barcode,@ScaleWeight", Para_Barcode, Para_ScaleWeight).FirstOrDefault();
        }

        /// <summary>
        /// SCANCOPY
        /// </summary>
        private void SCANCOPY()
        {
            var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = txtBarcode.Text };
            _ScannerInfo = dbContext.Database.SqlQuery<ScannerInfo>("dbo.sp_scanCOPY @Barcode", Para_Barcode).FirstOrDefault();
        }

        /// <summary>
        /// PRINTMIX
        /// </summary>
        private void PRINTMIX()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();

                if (_ScannerInfo.CountLabel == 0)
                {
                    for (int i = 1; i <= _ScannerInfo.MachineInfo.Split('-').Length; i++)
                    {
                        ListItem.Add(MixLabel(i.ToString("0#") + ".MIXED (TRỘN)", _ScannerInfo.TrackNo + "-MI", _ScannerInfo.ScaleWeight));
                        ListItem.Add(MixLabel(i.ToString("0#") + ".RUNNER (CUỐNG NHỰA)", _ScannerInfo.TrackNo + "-RU", 0));
                        ListItem.Add(MixLabel(i.ToString("0#") + ".DEFECT (PHẾ)", _ScannerInfo.TrackNo + "-DE", 0));
                        ListItem.Add(MixLabel(i.ToString("0#") + ".RED (CHẤM ĐEN)", _ScannerInfo.TrackNo + "-RE", 0));
                    }
                }
                else
                {
                    ListItem.Add(MixLabel("MIXED (TRỘN)", _ScannerInfo.TrackNo + "-MI", _ScannerInfo.ScaleWeight));
                    ListItem.Add(MixLabel("RUNNER (CUỐNG NHỰA)", _ScannerInfo.TrackNo + "-RU", 0));
                }

                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = string.Empty;

                Printer = MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTRETURN
        /// </summary>
        private void PRINTRETURN()
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
                    LabelName = "Thu hồi Nhựa",
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
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTRETURNOUT
        /// </summary>
        private void PRINTRETURNOUT()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();

                ListItem.Add(
                new SSBC_Data.Extend.LabelTemplate
                {
                    /// WinlineCode = _ScannerInfo.WinlineCo,
                    ItemName = _ScannerInfo.WinlineName,
                    ColorCode = _ScannerInfo.ColorCode,
                    ColorName = _ScannerInfo.ColorName,
                    MaterialCo = _ScannerInfo.MaterialCo,
                    MaterialName = _ScannerInfo.MaterialName,
                    MaterialType = _ScannerInfo.MaterialType,
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = "Xuất Nhựa Thu Hồi",
                    Barcode = _ScannerInfo.TrackNo,
                    BatchNo = _ScannerInfo.BatchNo.ToString(),
                    MachineInfo = _ScannerInfo.MachineInfo
                });

                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = string.Empty;

                Printer = MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTWHS
        /// </summary>
        private void PRINTWHS()
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
                    MaterialType = _ScannerInfo.MaterialType == "CP" ? "CP" : "RE",
                    ScaleWeight = _ScannerInfo.ScaleWeight,
                    ScaleDate = _ScannerInfo.ScaleDate,
                    LabelName = _ScannerInfo.MaterialType == "CP" ? "ĐÙN - WAREHOUSE" : "XAY - WAREHOUSE",
                    Barcode = _ScannerInfo.TrackNo,
                    BatchNo = _ScannerInfo.BatchNo.ToString(),
                    MachineInfo = string.Empty
                }
           );

                var MyReader = new System.Configuration.AppSettingsReader();
                string Printer = string.Empty;
                Printer = MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTCOMPOUND
        /// </summary>
        private void PRINTCOMPOUND()
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
                    BatchNo = _ScannerInfo.BatchNo.ToString(),
                    MachineInfo = string.Empty
                }
             );

                var MyReader = new System.Configuration.AppSettingsReader();
                string Printer = string.Empty;
                Printer = MyReader.GetValue("Printer_Yellow", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTCRUSH
        /// </summary>
        private void PRINTCRUSH()
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
                string Printer = string.Empty;
                Printer = _ScannerInfo.MaterialType == "CP" ? MyReader.GetValue("Printer_Yellow", typeof(string)).ToString() : MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode01 rep = new Report.rptLabelBarcode01();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTRED
        /// </summary>
        private void PRINTRED()
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
                    LabelName = _ScannerInfo.TrackNo.Split('-')[1] == "RE" ? "RED (CHẤM ĐEN)" : "HÀNG PHẾ (Hỗn Hợp)",
                    Barcode = _ScannerInfo.TrackNo,
                });

                var MyReader = new System.Configuration.AppSettingsReader();
                string Printer = string.Empty;
                Printer = MyReader.GetValue("Printer_Yellow", typeof(string)).ToString();
                Report.rptLabelBarcode01 rep = new Report.rptLabelBarcode01();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// PRINTCOPY
        /// </summary>
        private void PRINTCOPY()
        {
            try
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();
                string LabelName = string.Empty;

                if (_ScannerInfo.fBarcode.Substring(0, 2) == "MI")
                {
                    if (_ScannerInfo.fBarcode.Split('-')[1] == "MI")
                    {
                        LabelName = "Copy Mix (Trộn)";
                    }
                    else if (_ScannerInfo.fBarcode.Split('-')[1] == "RU")
                    {
                    }
                    else if (_ScannerInfo.fBarcode.Split('-')[1] == "DE")
                    {
                        LabelName = "Copy Defect (Phế)";
                    }
                    else if (_ScannerInfo.fBarcode.Split('-')[1] == "RE")
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
                    Barcode = _ScannerInfo.TrackNo + "-" + _ScannerInfo.fBarcode.Substring(_ScannerInfo.TrackNo.Length + 1, 2),
                    BatchNo = _ScannerInfo.BatchNo.ToString()
                });

                var MyReader = new System.Configuration.AppSettingsReader();

                string Printer = string.Empty;

                Printer = MyReader.GetValue("Printer_White", typeof(string)).ToString();

                Report.rptLabelBarcode rep = new Report.rptLabelBarcode();
                rep.CreateDocument(false);
                rep.Load(ListItem);
                rep.PrinterName = Printer;
                rep.Print();
                rep.Dispose();
                //rep.ShowPreview();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// dgvData_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblStatus.Text = "TRỘN NHỰA";
            //tabControl1.SelectedTab = TabPageInput;

            string sLabelName = string.Empty,
                   sBarcode = string.Empty,
                   sMaterialType = string.Empty,
                   sMachineInfo = string.Empty;

            rowIndex = dgvData.CurrentCell.RowIndex;
            columnIndex = dgvData.CurrentCell.ColumnIndex;

            dgvData.Rows[rowIndex].Cells[columnIndex].Value.ToString();

            if (dgvData.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "IN TEM")
            {
                var ListItem = new List<SSBC_Data.Extend.LabelTemplate>();
                var Label = new SSBC_Data.Extend.LabelTemplate();

                sBarcode = dgvData.Rows[rowIndex].Cells[9].Value.ToString();
                switch (TrackType)
                {
                    case "MIX":
                        sLabelName = "MIXED (TRỘN)";
                        sBarcode = sBarcode + "-MI";
                        sMaterialType = "RE";
                        sMachineInfo = dgvData.Rows[rowIndex].Cells[12].Value.ToString();
                        break;

                    case "WHS":
                        sLabelName = sBarcode.Substring(0, 2) == "CP" ? "ĐÙN - WAREHOUSE" : "XAY - WAREHOUSE";
                        sMaterialType = sBarcode.Substring(0, 2) == "CP" ? "CP" : "RE";
                        break;

                    case "RETURN":
                        sLabelName = "Thu hồi Nhựa";
                        sMaterialType = "RE";
                        break;

                    case "RETURN-OUT":
                        sLabelName = "Xuất Nhựa Thu Hồi";
                        sMaterialType = "RE";
                        break;

                    case "CRUSH":
                        sLabelName = "CRUSH (XAY)";
                        sMaterialType = "RE";
                        break;

                    case "COMPOUND":
                        sLabelName = "COMPOUND (ĐÙN)";
                        sMaterialType = "CP";
                        sMachineInfo = dgvData.Rows[rowIndex].Cells[12].Value.ToString();
                        break;

                    case "RED":
                        sLabelName = "RED (CHẤM ĐEN)";
                        sMaterialType = "RE";
                        break;
                }

                ListItem.Add(new SSBC_Data.Extend.LabelTemplate
                {
                    ItemName = dgvData.Rows[rowIndex].Cells[3].Value.ToString(),
                    ColorCode = Decimal.Parse(dgvData.Rows[rowIndex].Cells[4].Value.ToString()),
                    ColorName = dgvData.Rows[rowIndex].Cells[5].Value.ToString(),
                    MaterialCo = dgvData.Rows[rowIndex].Cells[6].Value.ToString(),
                    MaterialName = dgvData.Rows[rowIndex].Cells[7].Value.ToString(),
                    MaterialType = sMaterialType,
                    ScaleWeight = decimal.Parse(dgvData.Rows[rowIndex].Cells[8].Value.ToString()),
                    ScaleDate = DateTime.Parse(dgvData.Rows[rowIndex].Cells[2].Value.ToString()),
                    LabelName = sLabelName,
                    Barcode = sBarcode,
                    BatchNo = dgvData.Rows[rowIndex].Cells[11].Value.ToString(),
                    MachineInfo = sMachineInfo
                }
                );

                if (TrackType == "MIX")
                {
                    ListItem.Add(new SSBC_Data.Extend.LabelTemplate
                    {
                        ItemName = dgvData.Rows[rowIndex].Cells[3].Value.ToString(),
                        ColorCode = Decimal.Parse(dgvData.Rows[rowIndex].Cells[4].Value.ToString()),
                        ColorName = dgvData.Rows[rowIndex].Cells[5].Value.ToString(),
                        MaterialCo = dgvData.Rows[rowIndex].Cells[6].Value.ToString(),
                        MaterialName = dgvData.Rows[rowIndex].Cells[7].Value.ToString(),
                        MaterialType = sMaterialType,
                        ScaleWeight = 0,
                        ScaleDate = DateTime.Parse(dgvData.Rows[rowIndex].Cells[2].Value.ToString()),
                        LabelName = "RUNNER (CUỐNG NHỰA)",
                        Barcode = dgvData.Rows[rowIndex].Cells[9].Value.ToString() + "-RU",
                        BatchNo = dgvData.Rows[rowIndex].Cells[11].Value.ToString(),
                        MachineInfo = sMachineInfo,
                    }
                    );
                }

                Label = null;
                sLabelName = null;
                sBarcode = null;
                sMaterialType = null;
                sMachineInfo = null;

                var MyReader = new System.Configuration.AppSettingsReader();
                string Printer = string.Empty;

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

            if (dgvData.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "XÓA")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var Para_TrackType = new SqlParameter { ParameterName = "TrackType", Value = "MIX" };
                        var Para_Barcode = new SqlParameter { ParameterName = "Barcode", Value = dgvData.Rows[rowIndex].Cells[9].Value.ToString() };
                        //lblMsg.Visible = true;
                        //lblMsg.Text = dbContext.Database.SqlQuery<string>("dbo.sp_SSBC_Delete_Trackings @TrackType,@Barcode", Para_Barcode, Para_TrackType).FirstOrDefault();
                        notifi = dbContext.Database.SqlQuery<string>("dbo.sp_SSBC_Delete_Trackings @TrackType,@Barcode", Para_Barcode, Para_TrackType).FirstOrDefault();
                        MessageBox.Show(notifi);
                        LOOKUPMIX();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình xóa dữ liệu !");
                        ex.ToString();
                    }
                }

                return;
            }
        }

        #region GhiLog

        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = @"C:\\Logs\\";
            logFilePath = logFilePath + "Log-" + DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss") + "." + "txt";
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

        #endregion GhiLog

        //private void btnPre_Click(object sender, EventArgs e)
        //{
        //    if (pageNumber-1>0)
        //    {
        //        pageNumber--;
        //        dgvData.DataSource = LoadRecord(pageNumber, numRecord);
        //    }
        //}

        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    int totalRecord = 0;
        //    var dbContext   = new SSBC_Data.SourceContext();
        //    totalRecord     = dbContext.vSSBC_WhsTracks.Count();
        //    if (pageNumber - 1 < totalRecord / numRecord)
        //    {
        //        pageNumber++;
        //        dgvData.DataSource = LoadRecord(pageNumber, numRecord);
        //    }
        //}
    }
}