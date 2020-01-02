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
    public partial class StocksMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Source.Data.Entities.Stocks>
    {
        public void InitializeMapping()
        {

        }
        public StocksMap()
        {
            // table
            ToTable("Stocks", "dbo");

            // keys
            HasKey(t => new { t.Yy, t.Mm, t.ColorCode, t.MaterialCo, t.MaterialType, t.StockName });

            // Properties
            Property(t => t.Yy)
                .HasColumnName("YY")
                .HasMaxLength(2)
                .IsRequired();
            Property(t => t.Mm)
                .HasColumnName("MM")
                .HasMaxLength(2)
                .IsRequired();
            Property(t => t.ColorCode)
                .HasColumnName("ColorCode")
                .HasPrecision(18, 0)
                .IsRequired();
            Property(t => t.MaterialCo)
                .HasColumnName("MaterialCo")
                .HasMaxLength(50)
                .IsRequired();
            Property(t => t.MaterialType)
                .HasColumnName("MaterialType")
                .HasMaxLength(5)
                .IsRequired();
            Property(t => t.StockName)
                .HasColumnName("StockName")
                .HasMaxLength(15)
                .IsRequired();
            Property(t => t.QtyOpen)
                .HasColumnName("QtyOpen")
                .HasPrecision(18, 0)
                .IsOptional();
            Property(t => t.QtyIn)
                .HasColumnName("QtyIn")
                .HasPrecision(18, 0)
                .IsOptional();
            Property(t => t.QtyOut)
                .HasColumnName("QtyOut")
                .HasPrecision(18, 0)
                .IsOptional();
            Property(t => t.QtyEnd)
                .HasColumnName("QtyEnd")
                .HasPrecision(18, 0)
                .IsOptional();

            // Relationships

            InitializeMapping();
        }
    }
}

