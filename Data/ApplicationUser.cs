using Microsoft.AspNetCore.Identity;

namespace MySoko.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public byte[]? ProfilePhoto { get; set; }
    }
}
