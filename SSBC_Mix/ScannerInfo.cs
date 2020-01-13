using System;

namespace SSBC_Mix
{
    public class ScannerInfo
    {
        public string BarcodeInput { get; set; }//=ParentTrackNo
        public string Msg { get; set; }
        public string TrackNo { get; set; }
        public int ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public decimal ScaleWeight { get; set; }
        public DateTime ScaleDate { get; set; }

        //===========
        //public string WinlineCo { get; set; }
        public string WinlineName { get; set; }

        public int BatchNo { get; set; }
        public string MixTrackNo { get; set; }

        public int CountLabel { get; set; }

        public string MachineInfo { get; set; }
        public string fBarcode { get; set; }
    }
}