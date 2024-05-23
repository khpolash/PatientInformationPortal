using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.Application.ViewModels.VmEntities;

public class AllergiesDetailVm : BaseEntity
{
    public long PatientId { get; set; }
    public PatientVm Patient { get; set; }
    public long AllergiesId { get; set; }
    public AllergyVm Allergy { get; set; }
}
