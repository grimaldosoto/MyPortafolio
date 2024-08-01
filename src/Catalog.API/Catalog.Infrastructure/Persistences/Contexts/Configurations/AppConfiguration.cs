using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Persistences.Contexts.Configurations
{
    public class AppConfiguration : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {

            builder.ToTable("App", "MyPortafolio");

            builder.Property(e => e.AppId).HasColumnName("AppID");

            builder.Property(e => e.LiveLink)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ReleaseDate).HasColumnType("datetime");

            builder.Property(e => e.RepositoryLink)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Version)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
