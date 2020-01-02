//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------

namespace SSBC_Data.Mapping
{
    public partial class SSBCMaterialsMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.SSBCMaterials>
    {
        public void InitializeMapping()
        {
        }

        public SSBCMaterialsMap()
        {
            // table
            ToTable("SSBC_Materials", "dbo");

            // keys
            HasKey(t => t.MaterialCo);

            // Properties
            Property(t => t.MaterialCo)
                .HasColumnName("MaterialCo")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.MaterialName)
                .HasColumnName("MaterialName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.Unit)
                .HasColumnName("Unit")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.UserUpdate)
                .HasColumnName("UserUpdate")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.ReRe)
                .HasColumnName("RE_RE")
                .HasPrecision(18, 1)
                .IsOptional();
            Property(t => t.CpR)
                .HasColumnName("CP_R")
                .HasPrecision(18, 1)
                .IsOptional();
            Property(t => t.CpN)
                .HasColumnName("CP_N")
                .HasPrecision(18, 1)
                .IsOptional();
            Property(t => t.RESta)
                .HasColumnName("RE_Sta")
                .HasPrecision(18, 1)
                .IsOptional();
            Property(t => t.UserUpdateTime)
                .HasColumnName("UserUpdateTime")
                .IsOptional();
            Property(t => t.UserAdded)
                .HasColumnName("UserAdded")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.UserAddedTime)
                .HasColumnName("UserAddedTime")
                .IsOptional();

            // Relationships

            InitializeMapping();
        }
    }
}