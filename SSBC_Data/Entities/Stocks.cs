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
    public partial class Stocks: EntitiesObject
    {
        public Stocks()
        {
        }

        public string Yy { get; set; }
        public string Mm { get; set; }
        public decimal ColorCode { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialType { get; set; }
        public string StockName { get; set; }
        public decimal? QtyOpen { get; set; }
        public decimal? QtyIn { get; set; }
        public decimal? QtyOut { get; set; }
        public decimal? QtyEnd { get; set; }

    }
}