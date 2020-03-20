//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SSBC_Data.Views
{
    public partial class WinlineProducts : EntitiesObject
    {
        public WinlineProducts()
        {
        }

        public string WinlineCode { get; set; }
        public string Name { get; set; }
    }

    public partial class WinlineProductsItem
    {
        public static ObservableCollection<SSBC_Data.Entities.WinlineProducts> ItemsSource()
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.WinlineProducts>(dbcontext.WinlineProducts);
                var Items = (from a in list
                             select new SSBC_Data.Entities.WinlineProducts
                             {
                                 WinlineCode = a.WinlineCode,
                                 Name = a.Name,
                                 IsChecked = false,
                                 AutoId = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.WinlineProducts>(Items);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ObservableCollection<SSBC_Data.Entities.WinlineProducts>();
            }
        }
    }
}