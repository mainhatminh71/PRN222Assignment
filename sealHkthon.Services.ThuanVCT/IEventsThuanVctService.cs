using sealHkthon.Entities.MinhMN.Models;

namespace sealHkthon.Services.MinhMN
{
    public interface IEventsThuanVctService
    {
        Task<List<EventsThuanVct>> GetAllAsync();
        Task<EventsThuanVct?> GetByIdAsync(int id);
        Task<List<EventsThuanVct>> SearchAsync(string eventName, string description);
        Task<int> CreateAsync(EventsThuanVct entity);
        Task<int> UpdateAsync(EventsThuanVct entity);
        Task<bool> RemoveAsync(EventsThuanVct entity);
    }
}
