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
    public partial class SSBCMixVouchers : EntitiesObject
    {
        public SSBCMixVouchers()
        {
        }

        public int VoucherId { get; set; }
        public string ColorCo { get; set; }
        public string ColorName { get; set; }
        public string WinlineCo { get; set; }
        public string WinlineName { get; set; }
        public string O1 { get; set; }
        public string Do1 { get; set; }

        public int? BatchNo { get; set; }
        public int? TotalQty { get; set; }
    }
}