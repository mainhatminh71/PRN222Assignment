using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Repositories.MinhMN;

namespace sealHkthon.Services.MinhMN
{
    public class CriteriaItemsMinhMNService : ICriteriaItemsMinhMNService
    {
        private readonly CriteriaItemsMinhMNRepository _repository;

        public CriteriaItemsMinhMNService() => _repository = new CriteriaItemsMinhMNRepository();

        public async Task<List<CriteriaItemsMinhMN>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CriteriaItemsMinhMN?> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<CriteriaItemsMinhMN>> GetByCriteriaSetIdAsync(long criteriaSetIdMinhMN)
        {
            return await _repository.GetByCriteriaSetIdAsync(criteriaSetIdMinhMN);
        }

        public async Task<List<CriteriaItemsMinhMN>> SearchAsync(string criteriaName, string description)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(criteriaName) || string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Criteria name and description must not be empty.");

                return await _repository.SearchAsync(criteriaName, description);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> CreateAsync(CriteriaItemsMinhMN entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Criteria item must not be null.");
                if (string.IsNullOrWhiteSpace(entity.CriteriaName))
                    throw new ArgumentException("Criteria name must not be empty.");
                if (!entity.CriteriaSetIdMinhMN.HasValue || entity.CriteriaSetIdMinhMN.Value <= 0)
                    throw new ArgumentException("Criteria set id must be greater than zero.");

                return await _repository.CreateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> UpdateAsync(CriteriaItemsMinhMN entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Criteria item must not be null.");
                if (entity.CriteriaIdMinhMN <= 0)
                    throw new ArgumentException("Criteria id must be greater than zero.");
                if (string.IsNullOrWhiteSpace(entity.CriteriaName))
                    throw new ArgumentException("Criteria name must not be empty.");
                if (!entity.CriteriaSetIdMinhMN.HasValue || entity.CriteriaSetIdMinhMN.Value <= 0)
                    throw new ArgumentException("Criteria set id must be greater than zero.");

                return await _repository.UpdateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<bool> RemoveAsync(CriteriaItemsMinhMN entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Criteria item must not be null.");

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
