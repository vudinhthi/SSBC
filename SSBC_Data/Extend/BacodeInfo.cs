namespace SSBC_Data.Extend
{
    public class BacodeInfo
    {
        public string TrackNo { get; set; }
        public decimal? ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }

        //public decimal? ScaleWeight { get; set; }
        //public System.DateTime? ScaleDate { get; set; }
        public string WinlineCode { get; set; }

        public string ItemName { get; set; }
        public string ParentTrackNo { get; set; }
    }

    public class LabelTemplate
    {
        public decimal? ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public decimal? ScaleWeight { get; set; }
        public System.DateTime? ScaleDate { get; set; }
        public string WinlineCode { get; set; }
        public string ItemName { get; set; }
        public string LabelName { get; set; }
        public string Barcode { get; set; }
        public string BatchNo { get; set; }
        public string MachineInfo { get; set; }
        public string fBarcode { get; set; }
    }
}