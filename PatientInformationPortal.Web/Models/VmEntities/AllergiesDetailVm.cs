using PatientInformationPortal.Web.Models.VmEntities.Base;

namespace PatientInformationPortal.Web.Models.VmEntities;

public class AllergiesDetailVm : BaseEntity
{
    public long PatientId { get; set; }
    public PatientVm Patient { get; set; }
    public long AllergiesId { get; set; }
    public AllergyVm Allergy { get; set; }
}
