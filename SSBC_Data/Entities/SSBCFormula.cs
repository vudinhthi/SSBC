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
    public partial class SSBCFormula : EntitiesObject
    {
        public SSBCFormula()
        {
        }

        public int ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Pp { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime? UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime? UserAddedTime { get; set; }
    }
}