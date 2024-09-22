using Microsoft.AspNetCore.Identity;
using MySoko.Models;


namespace MySoko.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string? UserRoles { get; set; } = "Customer";
        public List<Product>? PurchaseHistory { get; set; }
    }

}
