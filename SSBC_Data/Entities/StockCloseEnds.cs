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
using System.Text;

namespace Source.Data.Entities
{
    public partial class StockCloseEnds: EntitiesObject
    {
        public StockCloseEnds()
        {
        }

        public string Yy { get; set; }
        public string Mm { get; set; }
        public string StockName { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsLock { get; set; }

    }
}