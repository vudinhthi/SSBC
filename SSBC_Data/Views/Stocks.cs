
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
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Source.Data.Views
{
    public partial class Stocks: EntitiesObject
    {
        public Stocks()
        {
        }
        
        public string Yy { get; set; }
        public string Mm { get; set; }
        public decimal? ColorCode { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialType { get; set; }
        public string StockName { get; set; }
        public decimal QtyOpen { get; set; }
        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public decimal QtyEnd { get; set; }
    }
    
    public partial class StocksItem
    {
    
        public static ObservableCollection<Source.Data.Entities.Stocks> ItemsSource()
        {
             try
            {
                var dbcontext = new Source.Data.SourceContext();
                var list = new ObservableCollection<Source.Data.Entities.Stocks>(dbcontext.Stocks);
                var Items = (from a in list
                             select new Source.Data.Entities.Stocks
                             {
                                 Yy=a.Yy,
                                 Mm=a.Mm,
                                 ColorCode=a.ColorCode,
                                 MaterialCo=a.MaterialCo,
                                 MaterialType=a.MaterialType,
                                 StockName=a.StockName,
                                 QtyOpen=a.QtyOpen,
                                 QtyIn=a.QtyIn,
                                 QtyOut=a.QtyOut,
                                 QtyEnd=a.QtyEnd,
                                 IsChecked = false,
                                 AutoId =Source.Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<Source.Data.Entities.Stocks>(Items);
            }
            catch (Exception err)
            {
                return new ObservableCollection<Source.Data.Entities.Stocks>();
            }
        }

    }
    
}