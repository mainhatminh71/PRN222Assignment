using Microsoft.AspNetCore.Mvc;
using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Services.MinhMN;

namespace sealHkthon.WebMVCApp.MinhMN.Controllers
{
    public class CriteriaTemplateMinhMNController : Controller
    {
        private readonly ICriteriaTemplateSetsMinhMNService _service;

        public CriteriaTemplateMinhMNController(ICriteriaTemplateSetsMinhMNService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _service.GetByIdAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("criteriaSetName,description,isDefault")] CriteriaTemplateSetsMinhMN item)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _service.GetByIdAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("criteriaSetIdMinhMN,criteriaSetName,description,isDefault,createdAt")] CriteriaTemplateSetsMinhMN item)
        {
            if (id != item.criteriaSetIdMinhMN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _service.GetByIdAsync(id.Value);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item != null)
            {
                await _service.RemoveAsync(item);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
