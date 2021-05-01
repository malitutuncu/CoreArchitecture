using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities.Roles
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasNoKey();
            builder.ToTable(name: "Roles");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(256);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
