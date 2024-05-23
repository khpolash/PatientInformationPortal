using PatientInformationPortal.Application.Repositories.Base;
using PatientInformationPortal.Infrastructure.Persistence;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Application.Repositories.Entities;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(PatientInformationPortalDbContext context) : base(context)
    {
    }
}
