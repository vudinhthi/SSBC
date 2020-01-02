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
    public partial class SSBCMaterials : EntitiesObject
    {
        public SSBCMaterials()
        {
        }

        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public decimal? ReRe { get; set; }
        public decimal? CpR { get; set; }
        public decimal? CpN { get; set; }
        public decimal? RESta { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime? UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime? UserAddedTime { get; set; }
    }
}