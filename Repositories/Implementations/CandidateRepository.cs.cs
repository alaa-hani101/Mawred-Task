using Mawred_Task.Data;
using Mawred_Task.Models;
using Mawred_Task.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mawred_Task.Repositories.Implementations
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
        }

        public async Task<List<Candidate>> GetAllAsync()
        {
            return await _context.Candidates
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Candidate?> GetByIdAsync(int id)
        {
            return await _context.Candidates
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Candidates
                .AnyAsync(x => x.Email == email);
        }

        public void Update(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
        }

        public void Delete(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}