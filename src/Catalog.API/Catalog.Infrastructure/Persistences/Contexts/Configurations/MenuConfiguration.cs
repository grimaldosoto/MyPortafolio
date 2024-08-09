﻿using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistences.Contexts.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus", "MyPortafolio");

            builder.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Url)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("URL");
        }
    }
}
