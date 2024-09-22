using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using MySoko.Models;
using System.Threading.Tasks;
using MySoko.Data;

namespace MySoko.Hubs
{
    public class ChatHub : Hub 
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(string user, string message)
        {
            // Use Context.User instead of User
            var signedInUser = await _userManager.GetUserAsync(Context.User);
            if signedInUser.UserRoles == "Admin"
            {
                await Client.All.SendAsync("ReceiveMessage", user, message);
            }
            else
            {
                
            }
        }
    }
}
