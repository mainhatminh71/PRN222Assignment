using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Repositories.MinhMN;

namespace sealHkthon.Services.MinhMN
{
    public class RoundsThuanVctService : IRoundsThuanVctService
    {
        private readonly RoundsThuanVctRepository _repository;

        public RoundsThuanVctService() => _repository = new RoundsThuanVctRepository();

        public async Task<List<RoundsThuanVct>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<RoundsThuanVct?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(RoundsThuanVct entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Round must not be null.");
                if (string.IsNullOrWhiteSpace(entity.RoundName))
                    throw new ArgumentException("Round name must not be empty.");
                if (entity.EventThuanVctid <= 0)
                    throw new ArgumentException("Event id must be greater than zero.");

                return await _repository.CreateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> UpdateAsync(RoundsThuanVct entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Round must not be null.");
                if (entity.RoundThuanVctid <= 0)
                    throw new ArgumentException("Round id must be greater than zero.");
                if (string.IsNullOrWhiteSpace(entity.RoundName))
                    throw new ArgumentException("Round name must not be empty.");
                if (entity.EventThuanVctid <= 0)
                    throw new ArgumentException("Event id must be greater than zero.");

                return await _repository.UpdateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<bool> RemoveAsync(RoundsThuanVct entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Round must not be null.");

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
