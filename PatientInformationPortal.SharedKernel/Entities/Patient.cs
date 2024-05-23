using PatientInformationPortal.SharedKernel.Core;
using PatientInformationPortal.SharedKernel.Entities.BaseEntities;

namespace PatientInformationPortal.SharedKernel.Entities;

public class Patient : AuditableEntity
{
    public Patient()
    {
        NCDDetails = new List<NCDDetail>();
        AllergiesDetails = new List<AllergiesDetail>();

    }
    public string Name { get; set; }
    public long DiseaseId { get; set; }
    public Disease Disease { get; set; }
    public Epilepsy Epilepsy { get; set; }
    public ICollection<NCDDetail> NCDDetails { get; set; }
    public ICollection<AllergiesDetail> AllergiesDetails { get; set; }
}
