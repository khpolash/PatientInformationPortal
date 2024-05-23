using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.SharedKernel.Entities;

public class Disease : AuditableEntity
{
    public string Name { get; set; }
    public ICollection<NCDDetail> NCDDetails { get; set; }
    public ICollection<Patient> Patients { get; set; }
}
