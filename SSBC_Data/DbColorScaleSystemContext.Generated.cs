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
        static SourceContext()
        {
            System.Data.Entity.Database.SetInitializer<SourceContext>(null);
        }

        //static string Connect = @"Data Source=192.168.190.5;Initial Catalog=dbColorSSBC;User ID=sa;Password=!fkv1209;";
        private static string Connect = @"Data Source=.;Initial Catalog=dbColorSSBC;User ID=sa;Password=p@ssw0rd;";

        public SourceContext()
            : base(Connect)
        { }

        //public SourceContext()
        //    : base("Name=SourceContext")
        //{ }
        public SourceContext(System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base("Name=SourceContext", model)
        { }

        public SourceContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public SourceContext(string nameOrConnectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(nameOrConnectionString, model)
        { }

        public SourceContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        { }

        public SourceContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        { }

        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCCompoundTrackings> SSBCCompoundTrackings { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCCrushTrackings> SSBCCrushTrackings { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCFormula> SSBCFormulas { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCInventoryFirst> SSBCInventoryFirsts { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCMaterials> SSBCMaterials { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCMixTrackings> SSBCMixTrackings { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCMixOutTrackings> SSBCMixOutTrackings { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCMixVouchers> SSBCMixVouchers { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCRedTrackings> SSBCRedTrackings { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.SSBCWHSTrackings> SSBCWHSTrackings { get; set; }
        public System.Data.Entity.DbSet<SSBC_Data.Entities.WinlineProducts> WinlineProducts { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCCompoundTrackingsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCCrushTrackingsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCFormulaMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCInventoryFirstMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCMaterialsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCMixTrackingsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCMixOutTrackingsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCMixVouchersMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCRedTrackingsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.SSBCWHSTrackingsMap());
            modelBuilder.Configurations.Add(new SSBC_Data.Mapping.WinlineProductsMap());

            InitializeMapping(modelBuilder);
        }
    }
}