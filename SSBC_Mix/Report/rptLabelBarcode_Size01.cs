﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using System.Collections.Generic;

namespace Source.Report
{
    public partial class rptLabelBarcode_Size01 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLabelBarcode_Size01()
        {
            InitializeComponent();
        }
        
        public void Load(List<Data.Entities.StationTracking> List)
        {
            //BindingList<Source.Data.SQLView.ViewBarcodes> ListData)


            this.DataSource = List;
            LoadDetail();
        }

        public void LoadDetail()
        {
            this.txtItemName.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ItemName"));
            this.txtColorCode.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ColorCode"));
            this.txtColorName.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ColorName")); 
            this.txtMaterialName.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "MaterialName"));

            this.txtScaleWeight.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ScaleWeight", "{0:#,###}"));
            this.txtDateScale.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ScaleDate", "{0:dd-MM-yyyy}"));
            ////this.txtGoodQty.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "GoodQty", "{0:#,###}"));
            ////this.txtBadQty.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "BadQty", "{0:#,###}"));
            ////this.txtQty.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "Qty", "{0:#,###}"));
            ///
            this.txtBarcode.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "Barcode")); 

            //this.txtBarcode.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "Barcode"));
            //this.txtPO.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "PO"));
            //this.txtStyle.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "StyleNo"));

            //this.txtCust.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "CustCode")); 

            //this.txtItemName.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ItemName"));
            //this.txtColor.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "ColorDisplay")); 
            //this.txtSizeCode.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "SizeCode"));
            //this.txtMold.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "Mold"));

            ////t
            //this.txtTotalBox.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "tTotalBox", "{0:#,##}"));
            //this.txtBoxSeq.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "BoxSeq", "{0:#,##}"));
            //this.txtQty.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "Qty", "{0:#,##}"));
            //this.txtBoxId.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "BoxId"));
            //this.txtOT.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "OT")); 




            //this.txtDisplayText02.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "DisplayText02"));
            //this.txtS1.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "S1", "{0:#,#0.00}"));
            //this.txtS2.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "S2", "{0:#,#0.00}"));
            //this.txtS3.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "S3", "{0:#,#0.00}"));





            //this.txtTotalOsQty.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "OsQty", "{0:#,###}"));
            ////this.txtTotalQty.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "Qty", "{0:#,###}"));

            //this.txtVoucherDate.DataBindings.Add(new DevExpress.XtraReports.UI.XRBinding("Text", null, "VoucherDate", "{0:dd-MM-yyyy}"));

        }
    }
}