using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Services.MinhMN;

namespace sealHkthon.WebMVCApp.MinhMN.Controllers
{
    public class CriteriaMinhMNController : Controller
    {
        private readonly ICriteriaItemsMinhMNService _service;
        private readonly ICriteriaTemplateSetsMinhMNService _templateService;

        public CriteriaMinhMNController(
            ICriteriaItemsMinhMNService service,
            ICriteriaTemplateSetsMinhMNService templateService)
        {
            _service = service;
            _templateService = templateService;
        }

        public async Task<IActionResult> Index(long? criteriaSetId)
        {
            var items = criteriaSetId.HasValue
                ? await _service.GetByCriteriaSetIdAsync(criteriaSetId.Value)
                : await _service.GetAllAsync();

            await PopulateTemplateSetsSelectListAsync(criteriaSetId);
            ViewBag.FilterCriteriaSetId = criteriaSetId;

            return View(items);
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

        public async Task<IActionResult> Create(long? criteriaSetId)
        {
            await PopulateTemplateSetsSelectListAsync(criteriaSetId);
            return View(new CriteriaItemsMinhMN
            {
                CriteriaSetIdMinhMN = criteriaSetId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CriteriaSetIdMinhMN,CriteriaName,Description,Weight,MaxScore")] CriteriaItemsMinhMN item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.CreateAsync(item);
                    return RedirectToAction(nameof(Index), new { criteriaSetId = item.CriteriaSetIdMinhMN });
                }
                catch (ApplicationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            await PopulateTemplateSetsSelectListAsync(item.CriteriaSetIdMinhMN);
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

            await PopulateTemplateSetsSelectListAsync(item.CriteriaSetIdMinhMN);
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
                try
                {
                    await _service.UpdateAsync(item);
                    return RedirectToAction(nameof(Index), new { criteriaSetId = item.CriteriaSetIdMinhMN });
                }
                catch (ApplicationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            await PopulateTemplateSetsSelectListAsync(item.CriteriaSetIdMinhMN);
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
        public async Task<IActionResult> DeleteConfirmed(long id, long? criteriaSetId)
        {
            var item = await _service.GetByIdAsync(id);
            if (item != null)
            {
                await _service.RemoveAsync(item);
                criteriaSetId ??= item.CriteriaSetIdMinhMN;
            }

            return RedirectToAction(nameof(Index), new { criteriaSetId });
        }

        private async Task PopulateTemplateSetsSelectListAsync(long? selectedId = null)
        {
            var sets = await _templateService.GetAllAsync();
            ViewBag.CriteriaSetIdMinhMN = new SelectList(sets, "criteriaSetIdMinhMN", "criteriaSetName", selectedId);
        }
    }
}
