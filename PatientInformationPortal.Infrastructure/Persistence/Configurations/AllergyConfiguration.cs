using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Infrastructure.Persistence.Configurations;

public class AllergyConfiguration : IEntityTypeConfiguration<Allergy>
{
    public void Configure(EntityTypeBuilder<Allergy> builder)
    {
        builder.ToTable("Allergies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasData(new Allergy
        {
            Id = 1,
            Name = "Drugs - Penicillins",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 2,
            Name = "Drugs - Others",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 3,
            Name = "Animals",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 4,
            Name = "Foods",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 5,
            Name = "Ointments",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 6,
            Name = "Plant",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 7,
            Name = "Spray",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 8,
            Name = "Others",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        }, new Allergy
        {
            Id = 9,
            Name = "No Allergies",
            CreatedBy = 1,
            CreatedDate = DateTime.Now,
        });
    }
}
