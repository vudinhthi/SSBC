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
    public partial class SSBCMixTrackings : EntitiesObject
    {
        public SSBCMixTrackings()
        {
        }

        public string TrackNo { get; set; }
        public string Year { get; set; }
        public int? Seq { get; set; }
        public decimal ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public decimal ScaleWeight { get; set; }
        public System.DateTime ScaleDate { get; set; }
        public string ProForBacode { get; set; }
        public string ItemName { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime UserAddedTime { get; set; }
    }

    public partial class SSBCMixTrackingsItem
    {
        public static ObservableCollection<SSBC_Data.Entities.SSBCMixTrackings> ItemsSource()
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                var list = new ObservableCollection<SSBC_Data.Entities.SSBCMixTrackings>(dbcontext.SSBCMixTrackings);
                var Items = (from a in list
                             select new SSBC_Data.Entities.SSBCMixTrackings
                             {
                                 TrackNo = a.TrackNo,
                                 Year = a.Year,
                                 Seq = a.Seq,
                                 ColorCode = a.ColorCode,
                                 MaterialCo = a.MaterialCo,
                                 MaterialType = a.MaterialType,
                                 ScaleWeight = a.ScaleWeight,
                                 ScaleDate = a.ScaleDate,
                                 WinlineCode = a.WinlineCode,
                                 ProForBacode = a.ProForBacode,
                                 UserUpdate = a.UserUpdate,
                                 UserUpdateTime = a.UserUpdateTime,
                                 UserAdded = a.UserAdded,
                                 UserAddedTime = a.UserAddedTime,
                                 IsChecked = false,
                                 AutoId = SSBC_Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<SSBC_Data.Entities.SSBCMixTrackings>(Items);
            }
            catch (Exception err)
            {
                return new ObservableCollection<SSBC_Data.Entities.SSBCMixTrackings>();
            }
        }

        public static SSBC_Data.Entities.SSBCMixTrackings GetByTrackNo(string TrackNo)
        {
            try
            {
                var dbcontext = new SSBC_Data.SourceContext();
                return dbcontext.SSBCMixTrackings.Where(x => x.TrackNo == TrackNo).First();
            }
            catch (Exception err)
            {
                return new SSBC_Data.Entities.SSBCMixTrackings();
            }
        }
    }
}