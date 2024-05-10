using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DontFlipIt.Models
{
    public class HotelUserEntity : IdentityUser
    {
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string LastName { get; set; } = string.Empty;
        public string BookingInfo { get; set; } = string.Empty;
        public bool CheckedIn { get; set; } = false;
        public bool CheckedOut { get; set; } = false;
    }
}
