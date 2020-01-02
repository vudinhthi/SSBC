
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
    public partial class StockCloseEnds: EntitiesObject
    {
        public StockCloseEnds()
        {
        }
        
        public string Yy { get; set; }
        public string Mm { get; set; }
        public string StockName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsLock { get; set; }
    }
    
    public partial class StockCloseEndsItem
    {
    
        public static ObservableCollection<Source.Data.Entities.StockCloseEnds> ItemsSource()
        {
             try
            {
                var dbcontext = new Source.Data.SourceContext();

                var listStock = dbcontext.Stocks.ToList().GroupBy(x => new { x.Yy, x.Mm }).Select(x1 => new Source.Data.Entities.StockCloseEnds {
                                    Yy = x1.Key.Yy,
                                    Mm = x1.Key.Mm,
                                    IsLock =false,
                                    IsDefault=false,
                                    IsChecked =false,
                                    AutoId = Source.Data.SourceContext.Action.CreateAutoID(),
                                        UpdateStatus = "Added"
                }).ToList();

                var list = dbcontext.StockCloseEnds.ToList();

                foreach (var item in listStock)
                {
                    var itemCheck = list.Where(x => x.Mm == item.Mm && x.Yy == item.Yy);

                    if (itemCheck.Count()>0)
                    {
                        
                        item.IsLock = itemCheck.First().IsLock==null?false:itemCheck.First().IsLock;
                        item.IsDefault = itemCheck.First().IsDefault==null?false: itemCheck.First().IsDefault;
                        item.UpdateStatus = "Modified";
                    }
                    
                }

                
               
                return new ObservableCollection<Source.Data.Entities.StockCloseEnds>(listStock);
            }
            catch (Exception err)
            {
                return new ObservableCollection<Source.Data.Entities.StockCloseEnds>();
            }
        }

    }
    
}