using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Infrastructure.Persistence.Configurations;

public class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.ToTable("Diseases");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(128);
        builder.HasData(new Disease
        {
            Id = 1,
            Name = "Asthma",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Disease
        {
            Id = 2,
            Name = "Cancer",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Disease
        {
            Id = 3,
            Name = "Disorders of ear",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Disease
        {
            Id = 4,
            Name = "Disorders of eye",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Disease
        {
            Id = 5,
            Name = "Mental Illness",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Disease
        {
            Id = 6,
            Name = "Oral Health problems",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        });
    }
}
