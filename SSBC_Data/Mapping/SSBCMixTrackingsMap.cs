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
    public partial class SSBCMixTrackingsMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.SSBCMixTrackings>
    {
        public void InitializeMapping()
        {
        }

        public SSBCMixTrackingsMap()
        {
            // table
            ToTable("SSBC_Mix_Trackings", "dbo");

            // keys
            HasKey(t => t.TrackNo);

            // Properties
            Property(t => t.TrackNo)
                .HasColumnName("TrackNo")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.Year)
                .HasColumnName("Year")
                .HasMaxLength(4)
                .IsRequired();
            Property(t => t.Seq)
                .HasColumnName("Seq")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();

            Property(t => t.ColorCode)
                .HasColumnName("ColorCode")
                .HasPrecision(18, 0)
                .IsOptional();

            Property(t => t.MaterialCo)
                .HasColumnName("MaterialCo")
                .HasMaxLength(50)
                .IsOptional();

            Property(t => t.MaterialType)
                .HasColumnName("MaterialType")
                .HasMaxLength(5)
                .IsOptional();
            Property(t => t.ScaleWeight)
                .HasColumnName("ScaleWeight")
                .HasPrecision(6, 1)
                .IsOptional();
            Property(t => t.ScaleDate)
                .HasColumnName("ScaleDate")
                .IsOptional();
            Property(t => t.WinlineCode)
                .HasColumnName("WinlineCode")
                .HasMaxLength(20)
                .IsOptional();
            Property(t => t.ProForBacode)
                .HasColumnName("ProForBacode")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.BatchNo)
               .HasColumnName("BatchNo")
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsOptional();
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