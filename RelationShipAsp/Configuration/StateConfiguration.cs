using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RelationShipAsp.Models;

namespace RelationShipAsp.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable(nameof(State));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.HasOne(x=>x.Country).WithMany(x=>x.State).HasForeignKey(x=>x.CountryId).OnDelete(DeleteBehavior.Restrict);
    }
}
