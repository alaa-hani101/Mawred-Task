using Mawred_Task.Enums;

namespace Mawred_Task.DTOs.Responses
{
    public class CandidateResponse
    {
        public int Id { get; set; }

        public string FullName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public Track Track { get; set; }

        public Level Level { get; set; }

        public CandidateStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}