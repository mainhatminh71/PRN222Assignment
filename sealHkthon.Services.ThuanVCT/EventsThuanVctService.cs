using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Repositories.MinhMN;

namespace sealHkthon.Services.MinhMN
{
    public class EventsThuanVctService : IEventsThuanVctService
    {
        private readonly EventsThuanVctRepository _repository;

        public EventsThuanVctService() => _repository = new EventsThuanVctRepository();

        public async Task<List<EventsThuanVct>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<EventsThuanVct?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<EventsThuanVct>> SearchAsync(string eventName, string description)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(eventName) || string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Event name and description must not be empty.");

                return await _repository.SearchAsync(eventName, description);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> CreateAsync(EventsThuanVct entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Event must not be null.");
                if (string.IsNullOrWhiteSpace(entity.EventName))
                    throw new ArgumentException("Event name must not be empty.");

                return await _repository.CreateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> UpdateAsync(EventsThuanVct entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Event must not be null.");
                if (entity.EventThuanVctid <= 0)
                    throw new ArgumentException("Event id must be greater than zero.");
                if (string.IsNullOrWhiteSpace(entity.EventName))
                    throw new ArgumentException("Event name must not be empty.");

                return await _repository.UpdateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<bool> RemoveAsync(EventsThuanVct entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Event must not be null.");

                return await _repository.RemoveAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }
    }
}
