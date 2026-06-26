using Mawred_Task.Models;

namespace Mawred_Task.Repositories.Interfaces
{
    public interface ICandidateRepository
    {
        Task AddAsync(Candidate candidate);

        Task<List<Candidate>> GetAllAsync();

        Task<Candidate?> GetByIdAsync(int id);

        Task<bool> EmailExistsAsync(string email);

        void Update(Candidate candidate);

        void Delete(Candidate candidate);

        Task SaveChangesAsync();
    }
}