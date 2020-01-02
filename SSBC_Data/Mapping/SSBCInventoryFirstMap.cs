//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;

namespace SSBC_Data.Mapping
{
    public partial class SSBCInventoryFirstMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.SSBCInventoryFirst>
    {
        public void InitializeMapping()
        {
        }

        public SSBCInventoryFirstMap()
        {
            // table
            ToTable("SSBC_InventoryFirst", "dbo");

            // keys
            HasKey(t => new { t.MaterialCo, t.ColorCode, t.MaterialType });

            // Properties
            Property(t => t.MaterialCo)
                .HasColumnName("MaterialCo")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.MaterialName)
                .HasColumnName("MaterialName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.ColorCode)
                .HasColumnName("ColorCode")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(t => t.ColorName)
                .HasColumnName("ColorName")
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
            Property(t => t.MaterialType)
                .HasColumnName("MaterialType")
                .HasMaxLength(5)
                .IsRequired();
            Property(t => t.Qty)
                .HasColumnName("Qty")
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