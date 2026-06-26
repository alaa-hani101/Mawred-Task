using Mawred_Task.Controllers.Base;
using Mawred_Task.DTOs.Requests;
using Mawred_Task.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mawred_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : AppControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] CreateCandidateRequest request)
        {
            var result = await _candidateService.AddAsync(request);

            return NewResult(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var result = await _candidateService.GetAllAsync();

            return NewResult(result);
        }

      
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetCandidateById(int id)
        {
            var result = await _candidateService.GetByIdAsync(id);

            return NewResult(result);
        }

      
        [HttpPatch("{id:int}/status")]
       
        public async Task<IActionResult> UpdateCandidateStatus(
            int id,
            [FromBody] UpdateCandidateStatusRequest request)
        {
            var result = await _candidateService.UpdateStatusAsync(id, request);

            return NewResult(result);
        }

        
        [HttpDelete("{id:int}")]
       
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var result = await _candidateService.DeleteAsync(id);

            return NewResult(result);
        }
    }
}