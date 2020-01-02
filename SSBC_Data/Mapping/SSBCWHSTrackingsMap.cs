﻿//------------------------------------------------------------------------------
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
    public partial class SSBCWHSTrackingsMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SSBC_Data.Entities.SSBCWHSTrackings>
    {
        public void InitializeMapping()
        {
        }

        public SSBCWHSTrackingsMap()
        {
            // table
            ToTable("SSBC_WHS_Trackings", "dbo");

            // keys
            HasKey(t => t.TrackNo);

            // Properties
            Property(t => t.TrackNo)
                .HasColumnName("TrackNo")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.Seq)
                .HasColumnName("Seq")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(t => t.ScaleWeight)
                .HasColumnName("ScaleWeight")
                .HasPrecision(6, 1)
                .IsOptional();
            Property(t => t.ScaleDate)
                .HasColumnName("ScaleDate")
                .IsOptional();
            Property(t => t.ParentTrackNo)
                .HasColumnName("ParentTrackNo")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.MixTrackNo)
               .HasColumnName("MixTrackNo")
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