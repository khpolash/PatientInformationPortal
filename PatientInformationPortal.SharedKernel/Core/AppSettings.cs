
namespace PatientInformationPortal.SharedKernel.Core;

public class AppSettings
{
    public Domain Domain { get; set; }


}

public class Domain
{
    public List<string> ClientOne { get; set; }

    public List<string> ClientTwo { get; set; }

    public List<string> All { get; set; }

    public string DomainName { get; set; }
}
