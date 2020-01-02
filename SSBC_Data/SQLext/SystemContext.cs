//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------

namespace SSBC_Data
{
    public partial class SourceContext
        : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSMStocks> vSMStocks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vLAStocks> vLAStocks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_MixTracks> vSSBC_MixTracks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_CompoundTracks> vSSBC_CompoundTracks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_CrushTracks> vSSBC_CrushTracks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_ProReturnTracks> vSSBC_ProReturnTracks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_ProReturnOutTracks> vSSBC_ProReturnOutTracks { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_WhsTracks> vSSBC_WhsTracks { get; set; }

        public System.Data.Entity.DbSet<SSBC_Data.SQLext.vSSBC_RedTracks> vSSBC_RedTracks { get; set; }
    }
}