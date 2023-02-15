using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<ECompany>
{
    public void Configure(EntityTypeBuilder<ECompany> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasIndex(c => c.Document).IsUnique();
        builder.Property(c => c.Document)
            .HasColumnType("varchar(14)")
            .IsRequired();
        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
        builder.Property(c => c.CommercialName)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .UseCollation("Latin1_General_CI_AI");
    }
}