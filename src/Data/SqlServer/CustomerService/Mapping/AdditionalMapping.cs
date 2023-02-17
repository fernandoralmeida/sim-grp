using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Mapping;

public class AdditionalsMapping : IEntityTypeConfiguration<EAdditional>
{
    public void Configure(EntityTypeBuilder<EAdditional> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(c => c.Key)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
        builder.Property(c => c.Value)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
    }
}