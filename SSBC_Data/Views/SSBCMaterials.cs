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
    public partial class SSBCMaterials : EntitiesObject
    {
        public SSBCMaterials()
        {
        }

        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
        public string UserUpdate { get; set; }
        public decimal ReRe { get; set; }
        public decimal CpR { get; set; }
        public decimal CpN { get; set; }
        public decimal RESta { get; set; }
        public System.DateTime UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime UserAddedTime { get; set; }
    }

    public partial class SSBCMaterialsItem
    {
        public static ObservableCollection<SSBC_Data.Entities.SSBCMaterials> ItemsSource()
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.SSBCMaterials>(dbcontext.SSBCMaterials);
                var Items = (from a in list
                             select new SSBC_Data.Entities.SSBCMaterials
                             {
                                 MaterialCo     = a.MaterialCo,
                                 MaterialName   = a.MaterialName,
                                 Unit           = a.Unit,
                                 UserUpdate     = a.UserUpdate,
                                 ReRe           = a.ReRe,
                                 CpR            = a.CpR,
                                 CpN            = a.CpN,
                                 RESta          = a.RESta,
                                 UserUpdateTime = a.UserUpdateTime,
                                 UserAdded      = a.UserAdded,
                                 UserAddedTime  = a.UserAddedTime,
                                 IsChecked      = false,
                                 AutoId         = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus   = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.SSBCMaterials>(Items);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ObservableCollection<SSBC_Data.Entities.SSBCMaterials>();
            }
        }
    }
}