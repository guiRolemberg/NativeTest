using Native.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Native.Infrastructure.Persistence.Configurations;
public class SneakerConfigurations : IEntityTypeConfiguration<Sneaker>
{
    public void Configure(EntityTypeBuilder<Sneaker> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.User)
            .WithMany(f => f.OwnedSneakers)
            .HasForeignKey(p => p.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
    }
}