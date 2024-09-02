using Microsoft.AspNetCore.Identity;

namespace MySoko.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public Roles? UserRoles { get; set; } = Roles.Customer;
    }

    public enum Roles
    {
        Admin,
        Merchant,
        Customer
    }
}
