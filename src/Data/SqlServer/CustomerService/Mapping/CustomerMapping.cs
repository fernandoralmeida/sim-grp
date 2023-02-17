using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<ECustomer>
{
    public void Configure(EntityTypeBuilder<ECustomer> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasIndex(c => c.Document).IsUnique();
        builder.Property(c => c.Document)
            .HasColumnType("varchar(11)")
            .IsRequired();
    }
}