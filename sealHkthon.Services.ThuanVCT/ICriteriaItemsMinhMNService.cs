using sealHkthon.Entities.MinhMN.Models;

namespace sealHkthon.Services.MinhMN
{
    public interface ICriteriaItemsMinhMNService
    {
        Task<List<CriteriaItemsMinhMN>> GetAllAsync();
        Task<CriteriaItemsMinhMN?> GetByIdAsync(long id);
        Task<List<CriteriaItemsMinhMN>> GetByCriteriaSetIdAsync(long criteriaSetIdMinhMN);
        Task<List<CriteriaItemsMinhMN>> SearchAsync(string criteriaName, string description);
        Task<int> CreateAsync(CriteriaItemsMinhMN entity);
        Task<int> UpdateAsync(CriteriaItemsMinhMN entity);
        Task<bool> RemoveAsync(CriteriaItemsMinhMN entity);
    }
}
