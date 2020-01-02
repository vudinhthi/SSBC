//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace SSBC_Data.Entities
{
    public partial class SSBCMixTrackings : EntitiesObject
    {
        public SSBCMixTrackings()
        {
        }

        public string TrackNo { get; set; }
        public string Year { get; set; }
        public int Seq { get; set; }
        public decimal? ColorCode { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialType { get; set; }
        public decimal? ScaleWeight { get; set; }
        public System.DateTime? ScaleDate { get; set; }
        public string WinlineCode { get; set; }
        public string ProForBacode { get; set; }
        public int BatchNo { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime? UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime? UserAddedTime { get; set; }

        [NotMapped]
        public int CountLabel { get; set; }
    }
}