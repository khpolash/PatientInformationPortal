using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.SharedKernel.Entities;

public class AllergiesDetail : AuditableEntity
{
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    public long AllergiesId { get; set; }
    public Allergy Allergy { get; set; }
}
