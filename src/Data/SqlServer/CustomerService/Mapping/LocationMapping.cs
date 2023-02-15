using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Mapping;

public class LocationMapping : IEntityTypeConfiguration<ELocation>
{
    public void Configure(EntityTypeBuilder<ELocation> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(c => c.Address)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
        builder.Property(c => c.District)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
        builder.Property(c => c.City)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
    }
}