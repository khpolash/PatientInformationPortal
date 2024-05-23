using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.SharedKernel.Entities;

public class NCDDetail : AuditableEntity
{
    public long PatientId { get; set; }
    public Patient Patient { get; set; }
    public long NCDId { get; set; }
    public Disease Disease { get; set; }
}
