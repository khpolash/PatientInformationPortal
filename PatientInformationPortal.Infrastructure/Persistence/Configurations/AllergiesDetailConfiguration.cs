using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Infrastructure.Persistence.Configurations;

public class AllergiesDetailConfiguration : IEntityTypeConfiguration<AllergiesDetail>
{
    public void Configure(EntityTypeBuilder<AllergiesDetail> builder)
    {
        builder.ToTable("AllergiesDetails");
        builder.HasKey(x => x.Id);
        builder.HasOne(ad => ad.Patient).WithMany(p => p.AllergiesDetails).HasForeignKey(ad => ad.PatientId);
        builder.HasOne(ad => ad.Allergy).WithMany(a => a.AllergiesDetails).HasForeignKey(ad => ad.AllergiesId);
    }
}
