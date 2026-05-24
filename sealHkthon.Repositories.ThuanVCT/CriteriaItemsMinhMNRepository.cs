using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.MinhMN.Models;

namespace sealHkthon.Repositories.MinhMN
{
    public class CriteriaItemsMinhMNRepository : Base.GenericRepository<CriteriaItemsMinhMN>
    {
        public CriteriaItemsMinhMNRepository()
        {
        }

        public CriteriaItemsMinhMNRepository(DBContext.PRN222_HACKATHONContext context) => _context = context;

        public new async Task<List<CriteriaItemsMinhMN>> GetAllAsync()
        {
            return await _context.CriteriaItemsMinhMNs
                .Include(c => c.CriteriaTemplateSetsMinhMN)
                .ToListAsync();
        }

        public async Task<CriteriaItemsMinhMN?> GetByIdAsync(long criteriaIdMinhMN)
        {
            return await _context.CriteriaItemsMinhMNs
                .Include(c => c.CriteriaTemplateSetsMinhMN)
                .FirstOrDefaultAsync(c => c.CriteriaIdMinhMN == criteriaIdMinhMN);
        }

        public async Task<List<CriteriaItemsMinhMN>> GetByCriteriaSetIdAsync(long criteriaSetIdMinhMN)
        {
            return await _context.CriteriaItemsMinhMNs
                .Where(c => c.CriteriaSetIdMinhMN == criteriaSetIdMinhMN)
                .ToListAsync();
        }

        public async Task<List<CriteriaItemsMinhMN>> SearchAsync(string criteriaName, string description)
        {
            return await _context.CriteriaItemsMinhMNs
                .Include(c => c.CriteriaTemplateSetsMinhMN)
                .Where(c => c.CriteriaName.Contains(criteriaName)
                    && c.Description.Contains(description))
                .ToListAsync();
        }
    }
}
