//------------------------------------------------------------------------------
// <Contact-Information>
//     Name : Huỳnh Trọng Hiếu
//     Dept : IT
//     Phone : 0858-002-022
//     Email : tronghieu388@gmail.com
// </Contact-Information>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Source.Data.Mapping
{
    public partial class StationTrackingMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Source.Data.Entities.StationTracking>
    {
        public void InitializeMapping()
        {

        }
        public StationTrackingMap()
        {
            // table
            ToTable("StationTracking", "dbo");

            // keys
            HasKey(t => t.SessionID);

            // Properties
            Property(t => t.SessionID)
                .HasColumnName("SessionID")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.Station)
                .HasColumnName("Station")
                .HasMaxLength(2)
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
            Property(t => t.ColorName)
                .HasColumnName("ColorName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.MaterialCo)
                .HasColumnName("MaterialCo")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.MaterialName)
                .HasColumnName("MaterialName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.MaterialType)
                .HasColumnName("MaterialType")
                .HasMaxLength(5)
                .IsOptional();
            Property(t => t.ScaleWeight)
                .HasColumnName("ScaleWeight")
                .HasPrecision(18, 0)
                .IsOptional();
            Property(t => t.ScaleDate)
                .HasColumnName("ScaleDate")
                .IsOptional();
            Property(t => t.WinlineCode)
                .HasColumnName("WinlineCode")
                .HasMaxLength(20)
                .IsOptional();
            Property(t => t.ItemName)
                .HasColumnName("ItemName")
                .HasMaxLength(150)
                .IsOptional();
            Property(t => t.SessionParent)
                .HasColumnName("SessionParent")
                .HasMaxLength(50)
                .IsOptional();
            Property(t => t.IsReturn)
                .HasColumnName("IsReturn")
                .IsOptional();
            Property(t => t.Reason)
                .HasColumnName("Reason")
                .HasMaxLength(150)
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

