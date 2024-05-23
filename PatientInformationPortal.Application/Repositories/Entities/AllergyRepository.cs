using PatientInformationPortal.Application.Repositories.Base;
using PatientInformationPortal.Infrastructure.Persistence;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Application.Repositories.Entities;

public class AllergyRepository : BaseRepository<Allergy>, IAllergyRepository
{
    public AllergyRepository(PatientInformationPortalDbContext context) : base(context)
    {
    }
}
