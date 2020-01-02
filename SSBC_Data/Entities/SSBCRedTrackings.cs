//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------

namespace SSBC_Data.Entities
{
    public partial class SSBCRedTrackings : EntitiesObject
    {
        public SSBCRedTrackings()
        {
        }

        public string TrackNo { get; set; }
        public int Seq { get; set; }
        public decimal? ScaleWeight { get; set; }
        public System.DateTime? ScaleDate { get; set; }
        public string ParentTrackNo { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime? UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime? UserAddedTime { get; set; }
    }
}