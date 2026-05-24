using sealHkthon.Entities.MinhMN.Models;
using sealHkthon.Repositories.MinhMN;

namespace sealHkthon.Services.MinhMN
{
    public class CriteriaTemplateSetsMinhMNService : ICriteriaTemplateSetsMinhMNService
    {
        private readonly CriteriaTemplateSetsMinhMNRepository _repository;

        public CriteriaTemplateSetsMinhMNService() => _repository = new CriteriaTemplateSetsMinhMNRepository();

        public async Task<List<CriteriaTemplateSetsMinhMN>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CriteriaTemplateSetsMinhMN?> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<CriteriaTemplateSetsMinhMN>> SearchAsync(string criteriaSetName, string description)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(criteriaSetName) || string.IsNullOrWhiteSpace(description))
                    throw new ArgumentException("Criteria set name and description must not be empty.");

                return await _repository.SearchAsync(criteriaSetName, description);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> CreateAsync(CriteriaTemplateSetsMinhMN entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Criteria template set must not be null.");
                if (string.IsNullOrWhiteSpace(entity.criteriaSetName))
                    throw new ArgumentException("Criteria set name must not be empty.");

                return await _repository.CreateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<int> UpdateAsync(CriteriaTemplateSetsMinhMN entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Criteria template set must not be null.");
                if (entity.criteriaSetIdMinhMN <= 0)
                    throw new ArgumentException("Criteria set id must be greater than zero.");
                if (string.IsNullOrWhiteSpace(entity.criteriaSetName))
                    throw new ArgumentException("Criteria set name must not be empty.");

                return await _repository.UpdateAsync(entity);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input validation error: {ex.Message}");
                throw new ApplicationException("Invalid input: " + ex.Message);
            }
        }

        public async Task<bool> RemoveAsync(CriteriaTemplateSetsMinhMN entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("Criteria template set must not be null.");

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
