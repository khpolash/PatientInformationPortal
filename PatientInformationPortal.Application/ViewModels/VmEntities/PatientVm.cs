using PatientInformationPortal.SharedKernel.Core;
using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.Application.ViewModels.VmEntities;

public class PatientVm : BaseEntity
{
    public string Name { get; set; }
    public long DiseaseId { get; set; }
    public Epilepsy Epilepsy { get; set; }

    public DiseaseVm Disease { get; set; }

    public List<int> NCDDetails { get; set; } = [];
    public List<int> AllergiesDetails { get; set; } = [];

}
