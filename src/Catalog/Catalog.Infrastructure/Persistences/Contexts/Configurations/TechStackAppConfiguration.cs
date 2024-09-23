using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Persistences.Contexts.Configurations
{
    public class TechStackAppConfiguration : IEntityTypeConfiguration<TechStackApp>
    {
        public void Configure(EntityTypeBuilder<TechStackApp> builder)
        {
            builder.ToTable("TechStackApp", "MyPortafolio");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("TechStackAppID");

            builder.Property(e => e.AppId).HasColumnName("AppID");

            builder.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

            builder.HasOne(d => d.App)
                .WithMany(p => p.TechStackApps)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_App_TechStackApp");

            builder.HasOne(d => d.Technology)
                .WithMany(p => p.TechStackApps)
                .HasForeignKey(d => d.TechnologyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TechnologyID_TechStackApp");
        }
    }
}
