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
    public partial class SSBCMixVouchersMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.SSBCMixVouchers>
    {
        public void InitializeMapping()
        {
        }

        public SSBCMixVouchersMap()
        {
            // table
            ToTable("SSBC_MixVouchers", "dbo");

            // keys
            HasKey(t => t.VoucherId);

            // Properties
            Property(t => t.VoucherId)
                .HasColumnName("VoucherId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(t => t.ColorCo)
                .HasColumnName("ColorCo")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.ColorName)
                .HasColumnName("ColorName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.WinlineCo)
                .HasColumnName("WinlineCo")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.WinlineName)
                .HasColumnName("WinlineName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.O1)
                .HasColumnName("O1")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.Do1)
                .HasColumnName("DO1")
                .HasMaxLength(150)
                .IsOptional();

            Property(t => t.BatchNo)
                .HasColumnName("BatchNo")
                .IsOptional();
            Property(t => t.TotalQty)
                .HasColumnName("TotalQty")
                .IsOptional();

            // Relationships

            InitializeMapping();
        }
    }
}