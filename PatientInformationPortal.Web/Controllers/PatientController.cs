using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using PatientInformationPortal.Web.Controllers.Base;
using PatientInformationPortal.Web.Models.VmEntities;
using System.Net.Http;

namespace PatientInformationPortal.Web.Controllers;

public class PatientController : BaseController
{
    public PatientController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    // GET: PatientController
    public async Task<ActionResult> Index()
    {
        var patientList = await GetEntityAsync<List<PatientVm>>("Patient");
        return View(patientList);
    }

    // GET: PatientController/Details/5
    public async Task<ActionResult> Details(long id)
    {
        var patient = await GetEntityAsync<PatientVm>("Patient/" + id);
        var allergyDetails = await GetEntityAsync<List<AllergiesDetailVm>>("AllergiesDetail");
        var allergyIds = allergyDetails.Where(x => x.PatientId == patient.Id).Select(x => x.AllergiesId).ToList();
        var ncdDetails = await GetEntityAsync<List<NCDDetailVm>>("NCDDetail");
        var ncdIds = ncdDetails.Where(x => x.PatientId == patient.Id).Select(x => x.NCDId).ToList();

        patient.AllergiesDetailsNames = await GetAllergyNamesByIds(allergyIds);
        patient.NCDDetailsNames = await GetNCDDetailsNamesByIds(ncdIds);
        return View(patient);
    }

    // GET: PatientController/Create
    public async Task<ActionResult> Create()
    {
        var model = new PatientVm
        {
            DiseaseDropdown = await GetDiseaseDropdown(),
            AllergyDropdown = await GetAllergyDropdown(),
        };
        return View(model);
    }


    // POST: PatientController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(PatientVm patient)
    {
        try
        {
            var result = await InsertEntityAsync("Patient", patient);
            await SaveNCDAndAllergyDetails(result.Id, patient.NCDDetails, patient.AllergiesDetails);
            TempData["successMessage"] = "Patient Created";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    // GET: PatientController/Edit/5
    public async Task<ActionResult> Edit(long id)
    {
        var patient = await GetEntityAsync<PatientVm>("Patient/" + id);

        if (patient == null)
        {
            return NotFound();
        }
        var allergyDetails = await GetEntityAsync<List<AllergiesDetailVm>>("AllergiesDetail");
        patient.AllergiesDetails = allergyDetails.Where(x => x.PatientId == patient.Id).Select(x => x.AllergiesId).ToList();
        var ncdDetails = await GetEntityAsync<List<NCDDetailVm>>("NCDDetail");
        patient.NCDDetails = ncdDetails.Where(x => x.PatientId == patient.Id).Select(x => x.NCDId).ToList();

        patient.DiseaseDropdown = await GetDiseaseDropdown();
        patient.AllergyDropdown = await GetAllergyDropdown();

        return View(patient);
    }

    // POST: PatientController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(long id, PatientVm patient)
    {
        try
        {
            var result = await UpdateEntityAsync("Patient/" + id, patient);
            var ncdDetailsList = await GetEntityAsync<List<NCDDetailVm>>("NCDDetail");
            var ncdDeletedId = ncdDetailsList.Where(x => x.PatientId == result.Id).Select(x => x.Id).ToArray();

            foreach (var delete in ncdDeletedId)
            {
                await DeleteEntityAsync("NCDDetail/" + delete);
            }
            var allergyDetailsList = await GetEntityAsync<List<AllergiesDetailVm>>("AllergiesDetail");
            var allergyDeleteId = allergyDetailsList.Where(x => x.PatientId == result.Id).Select(x => x.Id).ToArray();

            foreach (var delete in allergyDeleteId)
            {
                await DeleteEntityAsync("AllergiesDetail/" + delete);
            }

            await SaveNCDAndAllergyDetails(result.Id, patient.NCDDetails, patient.AllergiesDetails);
            TempData["successMessage"] = "Patient Updated";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    // GET: PatientController/Delete/5
    public async Task<ActionResult> Delete(long id)
    {
        var patient = await GetEntityAsync<PatientVm>("Patient/" + id);
        var allergyDetails = await GetEntityAsync<List<AllergiesDetailVm>>("AllergiesDetail");
        var allergyIds = allergyDetails.Where(x => x.PatientId == patient.Id).Select(x => x.AllergiesId).ToList();
        var ncdDetails = await GetEntityAsync<List<NCDDetailVm>>("NCDDetail");
        var ncdIds = ncdDetails.Where(x => x.PatientId == patient.Id).Select(x => x.NCDId).ToList();

        patient.AllergiesDetailsNames = await GetAllergyNamesByIds(allergyIds);
        patient.NCDDetailsNames = await GetNCDDetailsNamesByIds(ncdIds);
        return View(patient);
    }

    // POST: PatientController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(long id, IFormCollection collection)
    {
        try
        {
            var patient = await GetEntityAsync<PatientVm>("Patient/" + id);
            var ncdDetailsList = await GetEntityAsync<List<NCDDetailVm>>("NCDDetail");
            var ncdDeletedId = ncdDetailsList.Where(x => x.PatientId == patient.Id).Select(x => x.Id).ToArray();

            foreach (var delete in ncdDeletedId)
            {
                await DeleteEntityAsync("NCDDetail/" + delete);
            }
            var allergyDetailsList = await GetEntityAsync<List<AllergiesDetailVm>>("AllergiesDetail");
            var allergyDeleteId = allergyDetailsList.Where(x => x.PatientId == patient.Id).Select(x => x.Id).ToArray();

            foreach (var delete in ncdDeletedId)
            {
                await DeleteEntityAsync("AllergiesDetail/" + delete);
            }
            await DeleteEntityAsync("Patient/" + patient.Id);
            TempData["successMessage"] = "Patient Deleted";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    private async Task<List<SelectListItem>> GetDiseaseDropdown()
    {
        var diseaseList = await GetEntityAsync<List<DiseaseVm>>("Disease");
        if (diseaseList != null)
        {
            return diseaseList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
        else
        {
            return new List<SelectListItem>();
        }
    }

    private async Task<List<SelectListItem>> GetAllergyDropdown()
    {
        var allergyList = await GetEntityAsync<List<AllergyVm>>("Allergy");
        if (allergyList != null)
        {
            return allergyList.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
        else
        {
            return new List<SelectListItem>();
        }
    }

    private async Task SaveNCDAndAllergyDetails(long patientId, List<long> ncdDetails, List<long> allergiesDetails)
    {
        foreach (var ncdId in ncdDetails)
        {
            var ncdDetail = new NCDDetailVm
            {
                PatientId = patientId,
                NCDId = ncdId
            };
            await InsertEntityAsync("NCDDetail", ncdDetail);
        }

        foreach (var allergyId in allergiesDetails)
        {
            var allergyDetail = new AllergiesDetailVm
            {
                PatientId = patientId,
                AllergiesId = allergyId
            };
            await InsertEntityAsync("AllergiesDetail", allergyDetail);
        }
    }

    private async Task<List<string>> GetAllergyNamesByIds(List<long> allergyIds)
    {
        var allAllergies = await GetEntityAsync<List<AllergyVm>>("Allergy");
        var allergyNames = allergyIds.Select(id => allAllergies.FirstOrDefault(a => a.Id == id)?.Name ?? "Unknown Allergy")
            .ToList();
        return allergyNames;
    }

    private async Task<List<string>> GetNCDDetailsNamesByIds(List<long> ncdDetailsId)
    {
        var diseaseList = await GetEntityAsync<List<DiseaseVm>>("Disease");
        var ncdDetailsNames = ncdDetailsId.Select(id => diseaseList.FirstOrDefault(a => a.Id == id)?.Name ?? "Unknown Allergy").ToList();
        return ncdDetailsNames;
    }
}

