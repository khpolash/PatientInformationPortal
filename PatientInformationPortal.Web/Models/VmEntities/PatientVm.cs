using Microsoft.AspNetCore.Mvc.Rendering;
using PatientInformationPortal.Web.Collections;
using PatientInformationPortal.Web.Models.VmEntities.Base;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortal.Web.Models.VmEntities;

public class PatientVm : BaseEntity
{
    public PatientVm()
    {
        DiseaseDropdown = new List<SelectListItem>();
        AllergyDropdown = new List<SelectListItem>();
    }

    public string Name { get; set; }

    [Display(Name = "Disease")]
    public long DiseaseId { get; set; }
    public Epilepsy Epilepsy { get; set; }
    public DiseaseVm Disease { get; set; }

    public List<long> NCDDetails { get; set; } = new List<long>();
    public List<long> AllergiesDetails { get; set; } = new List<long>();
    public List<string> AllergiesDetailsNames { get; set; } = new List<string>();
    public List<string> NCDDetailsNames { get; set; } = new List<string>();
    public IEnumerable<SelectListItem> DiseaseDropdown { get; set; }
    public IEnumerable<SelectListItem> AllergyDropdown { get; set; }
}


