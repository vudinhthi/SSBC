//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSBC_Data.SQLext
{
    public partial class vSSBC_RedTracks
    {
        [NotMapped]
        public string btnDel { get; set; }

        [NotMapped]
        public string btnPrint { get; set; }

        public System.DateTime ScaleDate { get; set; }
        public string WinlineName { get; set; }
        public int ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public decimal ScaleWeight { get; set; }

        [Key]
        public string TrackNo { get; set; }

        public string ParentTrackNo { get; set; }
    }
}