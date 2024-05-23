using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Web.Controllers.Base;
using PatientInformationPortal.Web.Models.VmEntities;

namespace PatientInformationPortal.Web.Controllers;

public class AllergyController : BaseController
{
    public AllergyController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }

    // GET: AllergyController
    public async Task<ActionResult> Index()
    {
        var allergyList = await GetEntityAsync<List<AllergyVm>>("Allergy");
        return View(allergyList);
    }

    // GET: AllergyController/Details/5
    public async Task<ActionResult> Details(long id)
    {
        var allergy = await GetEntityAsync<AllergyVm>("Allergy/" + id);
        return View(allergy);
    }

    // GET: AllergyController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: AllergyController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(AllergyVm allergy)
    {
        try
        {
            await InsertEntityAsync("Allergy", allergy);
            TempData["successMessage"] = "Allergy Created";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    // GET: AllergyController/Edit/5
    public async Task<ActionResult> Edit(long id)
    {
        var allergy = await GetEntityAsync<AllergyVm>("Allergy/" + id);
        return View(allergy);
    }

    // POST: AllergyController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(long id, AllergyVm allergy)
    {
        try
        {
            await UpdateEntityAsync("Allergy/" + id, allergy);
            TempData["successMessage"] = "Allergy Updated";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

    // GET: AllergyController/Delete/5
    public async Task<ActionResult> Delete(long id)
    {
        var allergy = await GetEntityAsync<AllergyVm>("Allergy/" + id);
        return View(allergy);
    }

    // POST: AllergyController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(long id, IFormCollection collection)
    {
        try
        {
            await DeleteEntityAsync("Allergy/" + id);
            TempData["successMessage"] = "Allergy Deleted";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            TempData["errorMessage"] = ex.Message;
            return RedirectToAction("Index");
        }
    }

}
