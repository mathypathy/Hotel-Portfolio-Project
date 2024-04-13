using Microsoft.AspNetCore.Identity;

namespace DontFlipIt.Models
{
    public class MemberEntity : IdentityUser
    {
        public string firstname {get; set;} = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty; 
        public string password { get; set; } = string.Empty;


    }
}
