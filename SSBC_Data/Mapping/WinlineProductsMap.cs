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
    public partial class WinlineProductsMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.WinlineProducts>
    {
        public void InitializeMapping()
        {
        }

        public WinlineProductsMap()
        {
            // table
            ToTable("WinlineProducts", "dbo");

            // keys
            HasKey(t => t.WinlineCode);

            // Properties
            Property(t => t.WinlineCode)
                .HasColumnName("WinlineCode")
                .HasMaxLength(20)
                .IsRequired();
            Property(t => t.Name)
                .HasColumnName("Name")
                .HasMaxLength(150)
                .IsOptional();

            // Relationships

            InitializeMapping();
        }
    }
}