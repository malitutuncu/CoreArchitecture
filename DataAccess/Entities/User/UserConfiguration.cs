using Data.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.User
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200);
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ParolaHash).IsRequired();
            builder.Property(x => x.ParolaSalt).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
