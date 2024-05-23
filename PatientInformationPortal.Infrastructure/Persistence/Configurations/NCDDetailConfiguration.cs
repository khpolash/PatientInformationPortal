using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Infrastructure.Persistence.Configurations;

public class NCDDetailConfiguration : IEntityTypeConfiguration<NCDDetail>
{
    public void Configure(EntityTypeBuilder<NCDDetail> builder)
    {
        builder.ToTable("NCDDetails");
        builder.HasKey(x => x.Id);
        builder.HasOne(nd => nd.Patient).WithMany(p => p.NCDDetails).HasForeignKey(nd => nd.PatientId);
        builder.HasOne(nd => nd.Disease).WithMany(d => d.NCDDetails).HasForeignKey(nd => nd.NCDId);
    }
}
