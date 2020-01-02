//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Source.Data.Entities
{
    public partial class StationTracking: EntitiesObject
    {
        public StationTracking()
        {
        }

        public string SessionID { get; set; }
        public string Station { get; set; }
        public string Year { get; set; }
        public int Seq { get; set; }
        public decimal? ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public decimal? ScaleWeight { get; set; }
        public System.DateTime? ScaleDate { get; set; }
        public string WinlineCode { get; set; }
        public string ItemName { get; set; }
        public string SessionParent { get; set; }
        public bool? IsReturn { get; set; }
        public string Reason { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime? UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime? UserAddedTime { get; set; }

        [NotMapped]
        public string LabelName { get; set; }
        [NotMapped]
        public string Barcode { get; set; }


    }
}