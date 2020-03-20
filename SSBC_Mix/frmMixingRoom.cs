using DevExpress.ClipboardSource.SpreadsheetML;
using SSBC_Data;
using SSBC_Data.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSBC_Mix
{
    public partial class cbRecyclingLotNo : Form
    {
        public cbRecyclingLotNo()
        {
            InitializeComponent();
            LoadTable();
        }

        void LoadTable()
        {
           var listCategory = LoadData.Instance.LoadShiftList();
            cbShift.DataSource = listCategory;
            cbShift.DisplayMember = "MaterialName";
        }
    }
}
