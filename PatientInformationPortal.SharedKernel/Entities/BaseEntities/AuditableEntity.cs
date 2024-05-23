namespace PatientInformationPortal.SharedKernel.Entities.BaseEntities;

public class AuditableEntity<TId> : BaseEntity<TId>
{
    public DateTimeOffset CreatedDate { get; set; }

    public long CreatedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }
}

// abstract class
public class AuditableEntity : AuditableEntity<long>
{

}
