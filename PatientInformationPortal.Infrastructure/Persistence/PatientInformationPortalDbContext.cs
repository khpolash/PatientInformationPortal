using Microsoft.EntityFrameworkCore;
using PatientInformationPortal.Infrastructure.Persistence.Configurations;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Infrastructure.Persistence;

public class PatientInformationPortalDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Disease> Diseases { get; set; }
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<NCDDetail> NCD_Details { get; set; }
    public DbSet<AllergiesDetail> Allergies_Details { get; set; }

    public PatientInformationPortalDbContext(DbContextOptions<PatientInformationPortalDbContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(IPatientInformationPortalContext).Assembly);
        builder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys())
            .ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
    }
}
