using Mawred_Task.Enums;
using System.ComponentModel.DataAnnotations;

namespace Mawred_Task.DTOs.Requests
{
    public class CreateCandidateRequest
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(150, MinimumLength = 3)]
        public string FullName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Track is required.")]
        [EnumDataType(typeof(Track), ErrorMessage = "Invalid track.")]
        public Track Track { get; set; }

        [Required(ErrorMessage = "Level is required.")]
        [EnumDataType(typeof(Level), ErrorMessage = "Invalid level.")]
        public Level Level { get; set; }
    }
}