using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.SharedKernel.Entities;

public class Allergy : AuditableEntity
{
    public string Name { get; set; }
    public ICollection<AllergiesDetail> AllergiesDetails { get; set; }
}