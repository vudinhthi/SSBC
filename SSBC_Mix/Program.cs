using System;
using System.Windows.Forms;

namespace SSBC_Mix
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var MyReader = new System.Configuration.AppSettingsReader();
            string KeyStation = MyReader.GetValue("KeyStation", typeof(string)).ToString();

            //var frm = new frm.frmSSBC_Crush_Tracking();
            //var frm = new frm.frmSSBC_Compound_Tracking();
            //var frm = new frm.frmSSBC_Red_Tracking();
            //Application.Run(frm);
            switch (KeyStation)
            {
                case "MI":
                    var frm = new frmMixStation();
                    frm.Text = "MIXED";
                    Application.Run(frm);
                    break;

                case "CR":
                    var frmCR = new frmCrushStation();
                    frmCR.Text = "CRUSH";
                    Application.Run(frmCR);
                    break;

                case "CP":
                    var frmCP = new frmCPStation();
                    frmCP.Text = "COMPOUND";
                    Application.Run(frmCP);
                    break;

                case "RE":
                    var frmRE = new frmRedStation();
                    frmRE.Text = "COMPOUND";
                    Application.Run(frmRE);
                    break;

                case "COPY":
                    var frmCOPY = new frmCopyStation();
                    frmCOPY.Text = "COPY";
                    Application.Run(frmCOPY);
                    break;

                case "DATA":
                    var frmData = new frmExportData();
                    frmData.Text = "COPY";
                    Application.Run(frmData);
                    break;
            }
        }
    }
}