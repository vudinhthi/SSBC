
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
    public partial class StationTracking: EntitiesObject
    {
        public StationTracking()
        {
        }
        
        public string SessionID { get; set; }
        public string Station { get; set; }
        public string Year { get; set; }
        public int Seq { get; set; }
        public decimal ColorCode { get; set; }
        public string ColorName { get; set; }
        public string MaterialCo { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public decimal ScaleWeight { get; set; }
        public System.DateTime ScaleDate { get; set; }
        public string WinlineCode { get; set; }
        public string ItemName { get; set; }
        public string SessionParent { get; set; }
        public string UserUpdate { get; set; }
        public System.DateTime UserUpdateTime { get; set; }
        public string UserAdded { get; set; }
        public System.DateTime UserAddedTime { get; set; }
    }
    
    public partial class StationTrackingItem
    {
        public static ObservableCollection<Source.Data.Entities.StationTracking> AddNew()
        {
            return new ObservableCollection<Source.Data.Entities.StationTracking>();
        }
        public static ObservableCollection<Source.Data.Entities.StationTracking> ItemsSource(string _Station,String SessionSymbol)
        {
            try
            {
                var dbcontext = new Source.Data.SourceContext();
                var list = new ObservableCollection<Source.Data.Entities.StationTracking>(dbcontext.StationTrackings.Where(x => x.Station == _Station && x.SessionID.Substring(0,2)== SessionSymbol && x.IsReturn!=true ));
                var Items = (from a in list
                             select new Source.Data.Entities.StationTracking
                             {
                                 SessionID = a.SessionID,
                                 Station = a.Station,
                                 Year = a.Year,
                                 Seq = a.Seq,
                                 ColorCode = a.ColorCode,
                                 ColorName = a.ColorName,
                                 MaterialCo = a.MaterialCo,
                                 MaterialName = a.MaterialName,
                                 MaterialType = a.MaterialType,
                                 ScaleWeight = a.ScaleWeight,
                                 ScaleDate = a.ScaleDate,
                                 WinlineCode = a.WinlineCode,
                                 ItemName = a.ItemName,
                                 SessionParent = a.SessionParent,
                                 UserUpdate = a.UserUpdate,
                                 UserUpdateTime = a.UserUpdateTime,
                                 UserAdded = a.UserAdded,
                                 UserAddedTime = a.UserAddedTime,
                                 IsChecked = false,
                                 AutoId = Source.Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<Source.Data.Entities.StationTracking>(Items.OrderByDescending(x => x.ScaleDate));
            }
            catch (Exception err)
            {
                return new ObservableCollection<Source.Data.Entities.StationTracking>();
            }
        }
        public static ObservableCollection<Source.Data.Entities.StationTracking> ItemsSource(string _Station)
        {
             try
            {
                var dbcontext = new Source.Data.SourceContext();
                var list = new ObservableCollection<Source.Data.Entities.StationTracking>(dbcontext.StationTrackings.Where(x=>x.Station==_Station));
                var Items = (from a in list
                             select new Source.Data.Entities.StationTracking
                             {
                                 SessionID=a.SessionID,
                                 Station=a.Station,
                                 Year=a.Year,
                                 Seq=a.Seq,
                                 ColorCode=a.ColorCode,
                                 ColorName=a.ColorName,
                                 MaterialCo=a.MaterialCo,
                                 MaterialName=a.MaterialName,
                                 MaterialType=a.MaterialType,
                                 ScaleWeight=a.ScaleWeight,
                                 ScaleDate=a.ScaleDate,
                                 WinlineCode=a.WinlineCode,
                                 ItemName=a.ItemName,
                                 SessionParent=a.SessionParent,
                                 UserUpdate =a.UserUpdate,
                                 UserUpdateTime=a.UserUpdateTime,
                                 UserAdded=a.UserAdded,
                                 UserAddedTime=a.UserAddedTime,
                                 IsChecked = false,
                                 AutoId =Source.Data.SourceContext.Action.CreateAutoID(),
                                 UpdateStatus = "Unchanged"
                             }
                            );
                return new ObservableCollection<Source.Data.Entities.StationTracking>(Items.OrderByDescending(x=>x.ScaleDate));
            }
            catch (Exception err)
            {
                return new ObservableCollection<Source.Data.Entities.StationTracking>();
            }
        }


        public static Source.Data.Entities.StationTracking GetBySessionID(string _SesstionID)
        {
            try
            {
                var dbcontext = new Source.Data.SourceContext();
                return dbcontext.StationTrackings.Where(x => x.SessionID == _SesstionID).First();
               
            }
            catch (Exception err)
            {
                return new Source.Data.Entities.StationTracking();
            }
        }
    }


    public class Station {

       private string ID { get; set; }
       private string Name { get; set; }

        private static List<Station> GetList()
        {
            var _return = new List<Station>();
            _return.Add(new Station
            {
                ID="MI",
                Name="Mixed"
            });

            _return.Add(new Station
            {
                ID = "CR",
                Name = "Crush"
            });

            _return.Add(new Station
            {
                ID = "CP",
                Name = "Compound"
            });
            _return.Add(new Station
            {
                ID = "SM",
                Name = "Small Stock"
            });
            _return.Add(new Station
            {
                ID = "LA",
                Name = "Large Stock"
            });
            return _return;
        }

        public static String GetName(string _ID)
        {
            try {
                return GetList().Where(x => x.ID == _ID).First().Name;
            }
            catch(Exception err)
            {
                return "error";
            }
        }
    }
    
}