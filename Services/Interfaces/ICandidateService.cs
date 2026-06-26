using Mawred_Task.Common;
using Mawred_Task.DTOs.Requests;
using Mawred_Task.DTOs.Responses;

namespace Mawred_Task.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<Response<CandidateResponse>> AddAsync(CreateCandidateRequest request);

        Task<Response<List<CandidateResponse>>> GetAllAsync();

        Task<Response<CandidateResponse>> GetByIdAsync(int id);

        Task<Response<string>> UpdateStatusAsync(int id, UpdateCandidateStatusRequest request);

        Task<Response<string>> DeleteAsync(int id);
    }
}