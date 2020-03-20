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
    public partial class SSBCInventoryFirst : EntitiesObject
    {
        public SSBCInventoryFirst()
        {
        }

        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public int? ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Unit { get; set; }
        public string UserUpdate { get; set; }
        public string MaterialType { get; set; }
        public decimal Qty { get; set; }
        public System.DateTime UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime UserAddedTime { get; set; }
    }

    public partial class SSBCInventoryFirstItem
    {
        public static ObservableCollection<SSBC_Data.Entities.SSBCInventoryFirst> ItemsSource()
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.SSBCInventoryFirst>(dbcontext.SSBCInventoryFirsts);
                var Items = (from a in list
                             select new SSBC_Data.Entities.SSBCInventoryFirst
                             {
                                 MaterialCo = a.MaterialCo,
                                 MaterialName = a.MaterialName,
                                 ColorCode = a.ColorCode,
                                 ColorName = a.ColorName,
                                 Unit = a.Unit,
                                 UserUpdate = a.UserUpdate,
                                 MaterialType = a.MaterialType,
                                 Qty = a.Qty,
                                 UserUpdateTime = a.UserUpdateTime,
                                 UserAdded = a.UserAdded,
                                 UserAddedTime = a.UserAddedTime,
                                 IsChecked = false,
                                 AutoId = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.SSBCInventoryFirst>(Items);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ObservableCollection<SSBC_Data.Entities.SSBCInventoryFirst>();
            }
        }
    }
}