using sealHkthon.Entities.MinhMN.Models;

namespace sealHkthon.Services.MinhMN
{
    public interface IRoundsThuanVctService
    {
        Task<List<RoundsThuanVct>> GetAllAsync();
        Task<RoundsThuanVct?> GetByIdAsync(int id);
        Task<int> CreateAsync(RoundsThuanVct entity);
        Task<int> UpdateAsync(RoundsThuanVct entity);
        Task<bool> RemoveAsync(RoundsThuanVct entity);
    }
}
