using Mawred_Task.Common;
using Mawred_Task.DTOs.Requests;
using Mawred_Task.DTOs.Responses;
using Mawred_Task.Enums;
using Mawred_Task.Models;
using Mawred_Task.Repositories.Interfaces;
using Mawred_Task.Services.Interfaces;

namespace Mawred_Task.Services.Implementations
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ResponseHandler _responseHandler;

        public CandidateService(
            ICandidateRepository candidateRepository,
            ResponseHandler responseHandler)
        {
            _candidateRepository = candidateRepository;
            _responseHandler = responseHandler;
        }

        public async Task<Response<CandidateResponse>> AddAsync(CreateCandidateRequest request)
        {
            if (!Enum.IsDefined(typeof(Track), request.Track))
                return _responseHandler.BadRequest<CandidateResponse>("Invalid Track.");

            if (!Enum.IsDefined(typeof(Level), request.Level))
                return _responseHandler.BadRequest<CandidateResponse>("Invalid Level.");

            if (await _candidateRepository.EmailExistsAsync(request.Email))
                return _responseHandler.Conflict<CandidateResponse>("Email already exists.");

            var candidate = new Candidate
            {
                FullName = request.FullName,
                Email = request.Email,
                Track = request.Track,
                Level = request.Level,
                Status = CandidateStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _candidateRepository.AddAsync(candidate);
            await _candidateRepository.SaveChangesAsync();

            var response = new CandidateResponse
            {
                Id = candidate.Id,
                FullName = candidate.FullName,
                Email = candidate.Email,
                Track = candidate.Track,
                Level = candidate.Level,
                Status = candidate.Status,
                CreatedAt = candidate.CreatedAt
            };

            return _responseHandler.Created(response);
        }
        public async Task<Response<List<CandidateResponse>>> GetAllAsync()
        {
            var candidates = await _candidateRepository.GetAllAsync();

            var response = candidates.Select(c => new CandidateResponse
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                Track = c.Track,
                Level = c.Level,
                Status = c.Status,
                CreatedAt = c.CreatedAt
            }).ToList();

            return _responseHandler.Success(response);
        }

        public async Task<Response<CandidateResponse>> GetByIdAsync(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);

            if (candidate is null)
                return _responseHandler.NotFound<CandidateResponse>("Candidate not found.");

            var response = new CandidateResponse
            {
                Id = candidate.Id,
                FullName = candidate.FullName,
                Email = candidate.Email,
                Track = candidate.Track,
                Level = candidate.Level,
                Status = candidate.Status,
                CreatedAt = candidate.CreatedAt
            };

            return _responseHandler.Success(response);
        }
            public async Task<Response<string>> UpdateStatusAsync(int id, UpdateCandidateStatusRequest request)
        {
            if (!Enum.IsDefined(typeof(CandidateStatus), request.Status))
                return _responseHandler.BadRequest<string>("Invalid Status.");

            var candidate = await _candidateRepository.GetByIdAsync(id);

            if (candidate is null)
                return _responseHandler.NotFound<string>("Candidate not found.");

            candidate.Status = request.Status;

            _candidateRepository.Update(candidate);

            await _candidateRepository.SaveChangesAsync();

            return _responseHandler.Success("Candidate status updated successfully.");
        }


        public async Task<Response<string>> DeleteAsync(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);

            if (candidate is null)
                return _responseHandler.NotFound<string>("Candidate not found.");

            _candidateRepository.Delete(candidate);

            await _candidateRepository.SaveChangesAsync();

            return _responseHandler.Success<string>("Candidate deleted successfully.");
        }

    }
}
