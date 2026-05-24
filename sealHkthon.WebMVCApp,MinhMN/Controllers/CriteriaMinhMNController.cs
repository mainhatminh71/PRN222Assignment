using Microsoft.AspNetCore.Mvc;
using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Services.MinhMN;

namespace sealHkthon.WebMVCApp.MinhMN.Controllers
{
    public class CriteriaMinhMNController : Controller
    {
        private readonly ICriteriaItemsMinhMNService _service;

        public CriteriaMinhMNController(ICriteriaItemsMinhMNService service)
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
        public async Task<IActionResult> Create([Bind("CriteriaSetIdMinhMN,CriteriaName,Description,Weight,MaxScore")] CriteriaItemsMinhMN item)
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
        public async Task<IActionResult> Edit(long id, [Bind("CriteriaIdMinhMN,CriteriaSetIdMinhMN,CriteriaName,Description,Weight,MaxScore")] CriteriaItemsMinhMN item)
        {
            if (id != item.CriteriaIdMinhMN)
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
