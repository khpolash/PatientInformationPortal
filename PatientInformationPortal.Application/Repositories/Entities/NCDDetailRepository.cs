using PatientInformationPortal.Application.Repositories.Base;
using PatientInformationPortal.Infrastructure.Persistence;
using PatientInformationPortal.SharedKernel.Entities;

namespace PatientInformationPortal.Application.Repositories.Entities;

public class NCDDetailRepository : BaseRepository<NCDDetail>, INCDDetailRepository
{
    public NCDDetailRepository(PatientInformationPortalDbContext context) : base(context)
    {
    }
}
