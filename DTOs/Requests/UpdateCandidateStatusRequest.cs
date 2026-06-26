using Mawred_Task.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mawred_Task.DTOs.Requests
{
    public class UpdateCandidateStatusRequest
    {
        [Required]
        [EnumDataType(typeof(CandidateStatus), ErrorMessage = "Invalid status.")]
        public CandidateStatus Status { get; set; }
    }
}