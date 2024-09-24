using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using MySoko.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySoko.Data;

namespace MySoko.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public ChatHub(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
    
        }

        public async Task SendMessage(string user, string message)
        {
            var appUsers = await _userManager.Users.ToListAsync();
            var caller = Context.UserIdentifier;

            // Send message to all admins
            foreach (var appUser in appUsers)
            {
                if (appUser.UserRoles == "Admin" && appUser.Id != caller)
                {
                    await Clients.User(appUser.Id).SendAsync("ReceiveMessage", user, message);
                }
            }
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);

        }
        


        public async Task ReplyToUser (string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", "Admin", message);
        }
        
    }
}
