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

        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendMessage(string user, string message)
        {
            var appUsers = await _userManager.Users.ToListAsync();

            // Send message to all admins
            foreach (var appUser in appUsers)
            {
                if (appUser.UserRoles == "Admin")
                {
                    await Clients.User(appUser.Id).SendAsync("ReceiveMessage", user, message);
                }
            }

            // Optionally, you can notify the admin with a list of users who sent messages
            var userList = appUsers
                .Where(u => u.UserRoles != "Admin")
                .Select(u => new { u.Id, u.FirstName })
                .ToList();

            foreach (var appUser in appUsers)
            {
                if (appUser.UserRoles == "Admin")
                {
                    await Clients.User(appUser.Id).SendAsync("ReceiveUserList", userList);
                }
            }
        }

        public async Task ReplyToUser(string userId, string message)
        {
            // Send reply from admin to specific user
            await Clients.User(userId).SendAsync("ReceiveMessage", "Admin", message);
        }
    }
}
