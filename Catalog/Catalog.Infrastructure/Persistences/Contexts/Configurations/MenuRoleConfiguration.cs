using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Persistences.Contexts.Configurations
{
    public class MenuRoleConfiguration : IEntityTypeConfiguration<MenuRole>
    {
        public void Configure(EntityTypeBuilder<MenuRole> builder)
        {

            builder.HasKey(e => e.Id)
                   .HasName("PK__MenuRole__6640AD0C12D20D75");

            builder.Property(e => e.Id).HasColumnName("MenuRolId");

            builder.ToTable("MenuRoles", "MyPortafolio");

            builder.HasOne(d => d.Menu)
                .WithMany(p => p.MenuRoles)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_MenuRoles_Menu");

            builder.HasOne(d => d.Role)
                .WithMany(p => p.MenuRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_MenuRoles_Roles");
        }
    }
}
