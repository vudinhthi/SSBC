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
    public partial class SSBCMixVouchers : EntitiesObject
    {
        public SSBCMixVouchers()
        {
        }

        public int? VoucherId { get; set; }
        public string ColorCo { get; set; }
        public string ColorName { get; set; }
        public string WinlineCo { get; set; }
        public string WinlineName { get; set; }
        public string O1 { get; set; }
        public string Do1 { get; set; }
        public int BatchNo { get; set; }
        public int TotalQty { get; set; }
    }

    public partial class SSBCMixVouchersItem
    {
        public static ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers> ItemsSource()
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers>(dbcontext.SSBCMixVouchers);
                var Items = (from a in list
                             select new SSBC_Data.Entities.SSBCMixVouchers
                             {
                                 VoucherId    = a.VoucherId,
                                 ColorCo      = a.ColorCo,
                                 ColorName    = a.ColorName,
                                 WinlineCo    = a.WinlineCo,
                                 WinlineName  = a.WinlineName,
                                 O1           = a.O1,
                                 Do1          = a.Do1,
                                 BatchNo      = a.BatchNo,
                                 TotalQty     = a.TotalQty,
                                 IsChecked    = false,
                                 AutoId       = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers>(Items);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers>();
            }
        }

        public static ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers> GetByVoucherId(int VoucherId)
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers>(dbcontext.SSBCMixVouchers.Where(x => x.VoucherId == VoucherId));
                var Items = (from a in list
                             select new SSBC_Data.Entities.SSBCMixVouchers
                             {
                                 VoucherId    = a.VoucherId,
                                 ColorCo      = a.ColorCo,
                                 ColorName    = a.ColorName,
                                 WinlineCo    = a.WinlineCo,
                                 WinlineName  = a.WinlineName,
                                 O1           = a.O1,
                                 Do1          = a.Do1,
                                 BatchNo      = a.BatchNo,
                                 TotalQty     = a.TotalQty,
                                 IsChecked    = false,
                                 AutoId       = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers>(Items);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ObservableCollection<SSBC_Data.Entities.SSBCMixVouchers>();
            }
        }
    }
}