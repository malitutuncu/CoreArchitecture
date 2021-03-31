using Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class KullaniciConfiguration : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.ToTable(name: "Kullanici");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AdiSoyadi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.KullaniciAdi).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ParolaHash).IsRequired();
            builder.Property(x => x.ParolaSalt).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
