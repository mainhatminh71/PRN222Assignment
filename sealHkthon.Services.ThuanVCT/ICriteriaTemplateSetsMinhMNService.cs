using sealHkthon.Entities.MinhMN.Models;

namespace sealHkthon.Services.MinhMN
{
    public interface ICriteriaTemplateSetsMinhMNService
    {
        Task<List<CriteriaTemplateSetsMinhMN>> GetAllAsync();
        Task<CriteriaTemplateSetsMinhMN?> GetByIdAsync(long id);
        Task<List<CriteriaTemplateSetsMinhMN>> SearchAsync(string criteriaSetName, string description);
        Task<int> CreateAsync(CriteriaTemplateSetsMinhMN entity);
        Task<int> UpdateAsync(CriteriaTemplateSetsMinhMN entity);
        Task<bool> RemoveAsync(CriteriaTemplateSetsMinhMN entity);
    }
}
