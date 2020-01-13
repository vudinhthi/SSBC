//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SSBC_Data.SQLext
{
    public partial class vSMStocks : EntitiesObject
    {
        [Key]
        public string SessionID { get; set; }

        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public decimal Total { get; set; }

        public static Decimal GetTotal(string SessionID)
        {
            try
            {
                var dbContext = new SSBC_Data.SourceContext();
               // var Total = dbContext.vSMStocks.Where(x => x.SessionID == SessionID).FirstOrDefault().Total;
                var Total = dbContext.vSMStocks.FirstOrDefault(x => x.SessionID == SessionID).Total;
                return Total;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
        }
    }
}