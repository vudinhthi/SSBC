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
    public partial class SSBCFormula : EntitiesObject
    {
        public SSBCFormula()
        {
        }

        public int? ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Pp { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime UserAddedTime { get; set; }
    }

    public partial class SSBCFormulaItem
    {
        public static ObservableCollection<SSBC_Data.Entities.SSBCFormula> ItemsSource()
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.SSBCFormula>(dbcontext.SSBCFormulas);
                var Items = (from a in list
                             select new SSBC_Data.Entities.SSBCFormula
                             {
                                 ColorCode = a.ColorCode,
                                 ColorName = a.ColorName,
                                 Pp = a.Pp,
                                 UserUpdate = a.UserUpdate,
                                 UserUpdateTime = a.UserUpdateTime,
                                 UserAdded = a.UserAdded,
                                 UserAddedTime = a.UserAddedTime,
                                 IsChecked = false,
                                 AutoId = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.SSBCFormula>(Items);
            }
            catch (Exception err)
            {
                return new ObservableCollection<SSBC_Data.Entities.SSBCFormula>();
            }
        }
    }
}