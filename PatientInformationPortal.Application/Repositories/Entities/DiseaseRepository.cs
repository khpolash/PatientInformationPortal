using PatientInformationPortal.Application.Repositories.Base;
using PatientInformationPortal.Infrastructure.Persistence;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Application.Repositories.Entities;

public class DiseaseRepository : BaseRepository<Disease>, IDiseaseRepository
{
    public DiseaseRepository(PatientInformationPortalDbContext context) : base(context)
    {
    }
}
