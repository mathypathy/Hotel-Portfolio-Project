using System.ComponentModel.DataAnnotations;

namespace DontFlipIt.ViewModels
{
    public class HotelUserViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Firstname { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Lastname { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
