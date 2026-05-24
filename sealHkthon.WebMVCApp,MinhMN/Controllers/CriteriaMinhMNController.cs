using Microsoft.AspNetCore.Mvc;
using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Repositories.MinhMN;

namespace sealHkthon.WebMVCApp.MinhMN.Controllers
{
    public class CriteriaMinhMNController : Controller
    {
        private readonly CriteriaItemsMinhMNRepository _repository;

        public CriteriaMinhMNController()
        {
            _repository = new CriteriaItemsMinhMNRepository();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _repository.GetByIdAsync(id.Value);
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
                await _repository.CreateAsync(item);
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

            var item = await _repository.GetByIdAsync(id.Value);
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
                await _repository.UpdateAsync(item);
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

            var item = await _repository.GetByIdAsync(id.Value);
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
            var item = await _repository.GetByIdAsync(id);
            if (item != null)
            {
                await _repository.RemoveAsync(item);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
