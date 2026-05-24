using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.MinhMN.Models;

namespace sealHkthon.Repositories.MinhMN
{
    public class CriteriaTemplateSetsMinhMNRepository : Base.GenericRepository<CriteriaTemplateSetsMinhMN>
    {
        public CriteriaTemplateSetsMinhMNRepository()
        {
        }

        public CriteriaTemplateSetsMinhMNRepository(DBContext.PRN222_HACKATHONContext context) => _context = context;

        public new async Task<List<CriteriaTemplateSetsMinhMN>> GetAllAsync()
        {
            return await _context.CriteriaTemplateSetsMinhMNs
                .Include(s => s.CriteriaItemsMinhMNs)
                .ToListAsync();
        }

        public async Task<CriteriaTemplateSetsMinhMN?> GetByIdAsync(long criteriaSetIdMinhMN)
        {
            return await _context.CriteriaTemplateSetsMinhMNs
                .Include(s => s.CriteriaItemsMinhMNs)
                .FirstOrDefaultAsync(s => s.criteriaSetIdMinhMN == criteriaSetIdMinhMN);
        }

        public async Task<List<CriteriaTemplateSetsMinhMN>> SearchAsync(string criteriaSetName, string description)
        {
            return await _context.CriteriaTemplateSetsMinhMNs
                .Include(s => s.CriteriaItemsMinhMNs)
                .Where(s => s.criteriaSetName.Contains(criteriaSetName)
                    && s.description.Contains(description))
                .ToListAsync();
        }
    }
}
