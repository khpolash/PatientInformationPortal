using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.Application.ViewModels.VmEntities;

public class NCDDetailVm : BaseEntity
{
    public long PatientId { get; set; }
    public PatientVm Patient { get; set; }
    public long NCDId { get; set; }
    public DiseaseVm Disease { get; set; }
}
