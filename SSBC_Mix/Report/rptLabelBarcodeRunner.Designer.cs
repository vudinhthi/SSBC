namespace Source.Report
{
    partial class rptLabelBarcodeRunner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code39Generator code39Generator1 = new DevExpress.XtraPrinting.BarCode.Code39Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.panel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.txtBarcode = new DevExpress.XtraReports.UI.XRBarCode();
            this.txtDateScale = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtScaleWeight = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMaterialName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtColorCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.txtBarcodeDisplay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine16 = new DevExpress.XtraReports.UI.XRLine();
            this.txtLabelName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine11 = new DevExpress.XtraReports.UI.XRLine();
            this.txtColorName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine9 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel1});
            this.Detail.HeightF = 400F;
            this.Detail.Name = "Detail";
            // 
            // panel1
            // 
            this.panel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.panel1.CanGrow = false;
            this.panel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine8,
            this.txtBarcode,
            this.txtDateScale,
            this.xrLabel9,
            this.xrLabel6,
            this.xrLabel5,
            this.txtScaleWeight,
            this.txtMaterialName,
            this.txtColorCode,
            this.xrLine6,
            this.txtBarcodeDisplay,
            this.xrLine16,
            this.txtLabelName,
            this.xrLabel8,
            this.xrLine11,
            this.txtColorName,
            this.xrLabel3,
            this.xrLine9,
            this.xrLine5,
            this.xrLine4,
            this.xrLine3,
            this.xrLine1});
            this.panel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.panel1.Name = "panel1";
            this.panel1.SizeF = new System.Drawing.SizeF(390F, 390F);
            // 
            // txtBarcode
            // 
            this.txtBarcode.AutoModule = true;
            this.txtBarcode.LocationFloat = new DevExpress.Utils.PointFloat(19.33341F, 314.1667F);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.txtBarcode.ShowText = false;
            this.txtBarcode.SizeF = new System.Drawing.SizeF(339.4998F, 35F);
            code39Generator1.WideNarrowRatio = 3F;
            this.txtBarcode.Symbology = code39Generator1;
            // 
            // txtDateScale
            // 
            this.txtDateScale.BorderColor = System.Drawing.Color.Silver;
            this.txtDateScale.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtDateScale.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtDateScale.LocationFloat = new DevExpress.Utils.PointFloat(278.6666F, 29.08334F);
            this.txtDateScale.Multiline = true;
            this.txtDateScale.Name = "txtDateScale";
            this.txtDateScale.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDateScale.SizeF = new System.Drawing.SizeF(80.16672F, 20F);
            this.txtDateScale.StylePriority.UseBorderColor = false;
            this.txtDateScale.StylePriority.UseBorders = false;
            this.txtDateScale.StylePriority.UseFont = false;
            this.txtDateScale.StylePriority.UseTextAlignment = false;
            this.txtDateScale.Text = "25-11-2019";
            this.txtDateScale.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel9
            // 
            this.xrLabel9.BorderColor = System.Drawing.Color.Silver;
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(229.0416F, 29.08334F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(49.625F, 20F);
            this.xrLabel9.StylePriority.UseBorderColor = false;
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Date :";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(304.2083F, 269.4167F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(54.62497F, 20F);
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Kg";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(19.20835F, 269.4167F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(54.62497F, 20F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Q\'ty";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // txtScaleWeight
            // 
            this.txtScaleWeight.BorderColor = System.Drawing.Color.Silver;
            this.txtScaleWeight.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtScaleWeight.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            this.txtScaleWeight.LocationFloat = new DevExpress.Utils.PointFloat(105.0833F, 253.2083F);
            this.txtScaleWeight.Multiline = true;
            this.txtScaleWeight.Name = "txtScaleWeight";
            this.txtScaleWeight.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtScaleWeight.SizeF = new System.Drawing.SizeF(188.125F, 47.875F);
            this.txtScaleWeight.StylePriority.UseBorderColor = false;
            this.txtScaleWeight.StylePriority.UseBorders = false;
            this.txtScaleWeight.StylePriority.UseFont = false;
            this.txtScaleWeight.StylePriority.UseTextAlignment = false;
            this.txtScaleWeight.Text = "15";
            this.txtScaleWeight.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.BorderColor = System.Drawing.Color.Silver;
            this.txtMaterialName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtMaterialName.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.txtMaterialName.LocationFloat = new DevExpress.Utils.PointFloat(73.83331F, 177.4584F);
            this.txtMaterialName.Multiline = true;
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMaterialName.SizeF = new System.Drawing.SizeF(285F, 33.83331F);
            this.txtMaterialName.StylePriority.UseBorderColor = false;
            this.txtMaterialName.StylePriority.UseBorders = false;
            this.txtMaterialName.StylePriority.UseFont = false;
            this.txtMaterialName.StylePriority.UseTextAlignment = false;
            this.txtMaterialName.Text = "Color";
            this.txtMaterialName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtColorCode
            // 
            this.txtColorCode.BorderColor = System.Drawing.Color.Silver;
            this.txtColorCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtColorCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtColorCode.LocationFloat = new DevExpress.Utils.PointFloat(19.20834F, 109.5417F);
            this.txtColorCode.Multiline = true;
            this.txtColorCode.Name = "txtColorCode";
            this.txtColorCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtColorCode.SizeF = new System.Drawing.SizeF(48.58334F, 22.87499F);
            this.txtColorCode.StylePriority.UseBorderColor = false;
            this.txtColorCode.StylePriority.UseBorders = false;
            this.txtColorCode.StylePriority.UseFont = false;
            this.txtColorCode.StylePriority.UseTextAlignment = false;
            this.txtColorCode.Text = "2000";
            this.txtColorCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine6
            // 
            this.xrLine6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLine6.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(10.625F, 308.0833F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(359.375F, 2.083332F);
            this.xrLine6.StylePriority.UseBorders = false;
            // 
            // txtBarcodeDisplay
            // 
            this.txtBarcodeDisplay.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtBarcodeDisplay.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold);
            this.txtBarcodeDisplay.LocationFloat = new DevExpress.Utils.PointFloat(18.20834F, 353.25F);
            this.txtBarcodeDisplay.Multiline = true;
            this.txtBarcodeDisplay.Name = "txtBarcodeDisplay";
            this.txtBarcodeDisplay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBarcodeDisplay.SizeF = new System.Drawing.SizeF(340.6248F, 20F);
            this.txtBarcodeDisplay.StylePriority.UseBorders = false;
            this.txtBarcodeDisplay.StylePriority.UseFont = false;
            this.txtBarcodeDisplay.Text = "*11111111-888*";
            // 
            // xrLine16
            // 
            this.xrLine16.LocationFloat = new DevExpress.Utils.PointFloat(12.70834F, 374.9166F);
            this.xrLine16.Name = "xrLine16";
            this.xrLine16.SizeF = new System.Drawing.SizeF(359.375F, 2.083344F);
            // 
            // txtLabelName
            // 
            this.txtLabelName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtLabelName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.txtLabelName.LocationFloat = new DevExpress.Utils.PointFloat(16.33341F, 25.08335F);
            this.txtLabelName.Multiline = true;
            this.txtLabelName.Name = "txtLabelName";
            this.txtLabelName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLabelName.SizeF = new System.Drawing.SizeF(190.125F, 25F);
            this.txtLabelName.StylePriority.UseBorders = false;
            this.txtLabelName.StylePriority.UseFont = false;
            this.txtLabelName.StylePriority.UseTextAlignment = false;
            this.txtLabelName.Text = "Mixed";
            this.txtLabelName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(19.20834F, 184.2917F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(54.62497F, 20F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Polymer";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine11
            // 
            this.xrLine11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLine11.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.xrLine11.LocationFloat = new DevExpress.Utils.PointFloat(12.625F, 239.2917F);
            this.xrLine11.Name = "xrLine11";
            this.xrLine11.SizeF = new System.Drawing.SizeF(359.375F, 2.083332F);
            this.xrLine11.StylePriority.UseBorders = false;
            // 
            // txtColorName
            // 
            this.txtColorName.BorderColor = System.Drawing.Color.Silver;
            this.txtColorName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtColorName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.txtColorName.LocationFloat = new DevExpress.Utils.PointFloat(73.83331F, 84.54168F);
            this.txtColorName.Multiline = true;
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtColorName.SizeF = new System.Drawing.SizeF(285F, 47.875F);
            this.txtColorName.StylePriority.UseBorderColor = false;
            this.txtColorName.StylePriority.UseBorders = false;
            this.txtColorName.StylePriority.UseFont = false;
            this.txtColorName.StylePriority.UseTextAlignment = false;
            this.txtColorName.Text = "Color";
            this.txtColorName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(19.20835F, 85.54168F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(48.58334F, 15.44275F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Color";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine9
            // 
            this.xrLine9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLine9.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.xrLine9.LocationFloat = new DevExpress.Utils.PointFloat(13.70835F, 143.4167F);
            this.xrLine9.Name = "xrLine9";
            this.xrLine9.SizeF = new System.Drawing.SizeF(359.375F, 2.083336F);
            this.xrLine9.StylePriority.UseBorders = false;
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(12.625F, 63.00002F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(359.375F, 2.083332F);
            // 
            // xrLine4
            // 
            this.xrLine4.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(370F, 10.00001F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(2.083344F, 370F);
            // 
            // xrLine3
            // 
            this.xrLine3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(10.625F, 12.08334F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(2.083333F, 367.9166F);
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 10.00001F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(359.375F, 2.083333F);
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 4F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // xrLine8
            // 
            this.xrLine8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLine8.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine8.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.xrLine8.LocationFloat = new DevExpress.Utils.PointFloat(224.5F, 12.00002F);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.SizeF = new System.Drawing.SizeF(2.083328F, 50.99999F);
            this.xrLine8.StylePriority.UseBorders = false;
            // 
            // rptLabelBarcodeRunner
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(8, 0, 4, 0);
            this.PageHeight = 400;
            this.PageWidth = 400;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPanel panel1;
        private DevExpress.XtraReports.UI.XRLine xrLine16;
        private DevExpress.XtraReports.UI.XRLabel txtLabelName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLine xrLine11;
        private DevExpress.XtraReports.UI.XRLabel txtColorName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine9;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel txtBarcodeDisplay;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLabel txtColorCode;
        private DevExpress.XtraReports.UI.XRLabel txtMaterialName;
        private DevExpress.XtraReports.UI.XRLabel txtScaleWeight;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel txtDateScale;
        private DevExpress.XtraReports.UI.XRBarCode txtBarcode;
        private DevExpress.XtraReports.UI.XRLine xrLine8;
    }
}
