using PatientInformationPortal.Application.Repositories.Base;
using PatientInformationPortal.Infrastructure.Persistence;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Application.Repositories.Entities;

public class AllergiesDetailRepository : BaseRepository<AllergiesDetail>, IAllergiesDetailRepository
{
    public AllergiesDetailRepository(PatientInformationPortalDbContext context) : base(context)
    {
    }
}
