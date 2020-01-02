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
    public partial class StockCloseEndsMap
        : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Source.Data.Entities.StockCloseEnds>
    {
        public void InitializeMapping()
        {

        }
        public StockCloseEndsMap()
        {
            // table
            ToTable("StockCloseEnds", "dbo");

            // keys
            HasKey(t => new { t.Yy, t.Mm, t.StockName });

            // Properties
            Property(t => t.Yy)
                .HasColumnName("YY")
                .HasMaxLength(2)
                .IsRequired();
            Property(t => t.Mm)
                .HasColumnName("MM")
                .HasMaxLength(2)
                .IsRequired();
            Property(t => t.StockName)
                .HasColumnName("StockName")
                .HasMaxLength(15)
                .IsRequired();
            Property(t => t.IsDefault)
                .HasColumnName("IsDefault")
                .IsOptional();
            Property(t => t.IsLock)
                .HasColumnName("IsLock")
                .IsOptional();

            // Relationships

            InitializeMapping();
        }
    }
}

