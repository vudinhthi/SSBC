//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System.Collections.ObjectModel;

namespace SSBC_Data.Extend
{
    public partial class Excel : EntitiesObject
    {
        #region A->Z

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public string G { get; set; }
        public string H { get; set; }
        public string I { get; set; }
        public string J { get; set; }
        public string K { get; set; }
        public string L { get; set; }
        public string M { get; set; }
        public string N { get; set; }
        public string O { get; set; }
        public string P { get; set; }
        public string Q { get; set; }
        public string R { get; set; }
        public string S { get; set; }
        public string T { get; set; }
        public string U { get; set; }
        public string V { get; set; }
        public string W { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }

        #endregion A->Z

        #region AA->AZ

        public string AA { get; set; }
        public string AB { get; set; }
        public string AC { get; set; }
        public string AD { get; set; }
        public string AE { get; set; }
        public string AF { get; set; }
        public string AG { get; set; }
        public string AH { get; set; }
        public string AI { get; set; }
        public string AJ { get; set; }
        public string AK { get; set; }
        public string AL { get; set; }
        public string AM { get; set; }
        public string AN { get; set; }
        public string AO { get; set; }
        public string AP { get; set; }
        public string AQ { get; set; }
        public string AR { get; set; }
        public string AS { get; set; }
        public string AT { get; set; }
        public string AU { get; set; }
        public string AV { get; set; }
        public string AW { get; set; }
        public string AX { get; set; }
        public string AY { get; set; }
        public string AZ { get; set; }

        #endregion AA->AZ

        #region BA->BZ

        public string BA { get; set; }
        public string BB { get; set; }
        public string BC { get; set; }
        public string BD { get; set; }
        public string BE { get; set; }
        public string BF { get; set; }
        public string BG { get; set; }
        public string BH { get; set; }
        public string BI { get; set; }
        public string BJ { get; set; }
        public string BK { get; set; }
        public string BL { get; set; }
        public string BM { get; set; }
        public string BN { get; set; }
        public string BO { get; set; }
        public string BP { get; set; }
        public string BQ { get; set; }
        public string BR { get; set; }
        public string BS { get; set; }
        public string BT { get; set; }
        public string BU { get; set; }
        public string BV { get; set; }
        public string BW { get; set; }
        public string BX { get; set; }
        public string BY { get; set; }
        public string BZ { get; set; }

        #endregion BA->BZ

        #region CA->CZ

        public string CA { get; set; }
        public string CB { get; set; }
        public string CC { get; set; }
        public string CD { get; set; }
        public string CE { get; set; }
        public string CF { get; set; }
        public string CG { get; set; }
        public string CH { get; set; }
        public string CI { get; set; }
        public string CJ { get; set; }
        public string CK { get; set; }
        public string CL { get; set; }
        public string CM { get; set; }
        public string CN { get; set; }
        public string CO { get; set; }
        public string CP { get; set; }
        public string CQ { get; set; }
        public string CR { get; set; }
        public string CS { get; set; }
        public string CT { get; set; }
        public string CU { get; set; }
        public string CV { get; set; }
        public string CW { get; set; }
        public string CX { get; set; }
        public string CY { get; set; }
        public string CZ { get; set; }

        #endregion CA->CZ

        public static ObservableCollection<Excel> DataFile { get; set; }

        public static ObservableCollection<Excel> ItemsSource()
        {
            return new ObservableCollection<Excel>();
        }
    }
}