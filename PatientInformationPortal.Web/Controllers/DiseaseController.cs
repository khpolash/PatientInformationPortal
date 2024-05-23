using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Web.Controllers.Base;
using PatientInformationPortal.Web.Models.VmEntities;

namespace PatientInformationPortal.Web.Controllers
{
    public class DiseaseController : BaseController
    {
        public DiseaseController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        // GET: DiseaseController
        public async Task<ActionResult> Index()
        {
            var diseaseList = await GetEntityAsync<List<DiseaseVm>>("Disease");
            return View(diseaseList);
        }

        // GET: DiseaseController/Details/5
        public async Task<ActionResult> Details(long id)
        {
            var disease = await GetEntityAsync<DiseaseVm>("Disease/" + id);
            return View(disease);
        }

        // GET: DiseaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiseaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DiseaseVm disease)
        {
            try
            {
                await InsertEntityAsync("Disease", disease);
                TempData["successMessage"] = "Disease Created";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: DiseaseController/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            var disease = await GetEntityAsync<DiseaseVm>("Disease/" + id);
            return View(disease);
        }

        // POST: DiseaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, DiseaseVm disease)
        {
            try
            {
                await UpdateEntityAsync("Disease/" + id, disease);
                TempData["successMessage"] = "Disease Updated";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: DiseaseController/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var disease = await GetEntityAsync<DiseaseVm>("Disease/" + id);
            return View(disease);
        }

        // POST: DiseaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long id, IFormCollection collection)
        {
            try
            {
                await DeleteEntityAsync("Disease/" + id);
                TempData["successMessage"] = "Disease Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
