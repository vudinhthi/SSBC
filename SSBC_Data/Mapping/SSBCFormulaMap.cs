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
    public partial class SSBCFormulaMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.SSBCFormula>
    {
        public void InitializeMapping()
        {
        }

        public SSBCFormulaMap()
        {
            // table
            ToTable("SSBC_Formula", "dbo");

            // keys
            HasKey(t => t.ColorCode);

            // Properties
            Property(t => t.ColorCode)
                .HasColumnName("ColorCode")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(t => t.ColorName)
                .HasColumnName("ColorName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.Pp)
                .HasColumnName("PP")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.UserUpdate)
                .HasColumnName("UserUpdate")
                .HasMaxLength(50)
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