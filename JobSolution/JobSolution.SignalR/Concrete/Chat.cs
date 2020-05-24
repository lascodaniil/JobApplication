using JobSolution.SignalR.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using JobSolution.Infrastructure.Database;

namespace JobSolution.SignalR.Concrete
{
    public class Chat : Hub, IChat
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<int, bool> _IsEmployerOnlineInGroup;
        private static List<string> _OnlineUsers = new List<string>();

        public Chat(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            _IsEmployerOnlineInGroup = new Dictionary<int, bool>();
        }

        
        public async Task NewOnlineUser(string jwtToken)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwtToken);
            var claims = token.Claims;

            int user_id = 0;

            foreach (var item in claims)
            {
                if (item.Type == "UserId") user_id = Int32.Parse(item.Value);
            }

            if (user_id != 0)
            {
                var name = GetFullName(user_id);
                if (!_OnlineUsers.Contains(name))
                {
                    _OnlineUsers.Add(name);
                }
            }

            await Clients.All.SendAsync("OnlineUsers", _OnlineUsers);
        }

        public async Task LeaveRoom(int employerId, string jwtToken)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwtToken);
            var claims = token.Claims;

            int user_id = 0;

            foreach (var item in claims)
            {
                if (item.Type == "UserId") user_id = Int32.Parse(item.Value);
            }

            if (user_id != 0)
            {
                var name = GetFullName(user_id);
                if (_OnlineUsers.Contains(name))
                {
                    _OnlineUsers.Remove(name);
                }
            }

            await Clients.All.SendAsync("OnlineUsers", _OnlineUsers);
        }

        public async Task LogoutUser(string jwtToken)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwtToken);
            var claims = token.Claims;

            int user_id = 0;

            foreach (var item in claims)
            {
                if (item.Type == "UserId") user_id = Int32.Parse(item.Value);
            }

            if (user_id != 0)
            {
                var name = GetFullName(user_id);
                if (_OnlineUsers.Contains(name))
                {
                    _OnlineUsers.Remove(name);
                }
            }

            await Clients.All.SendAsync("OnlineUsers", _OnlineUsers);
        }

        public async Task SendMessage(string jwtToken, int employerId, string message)
        {
            await Clients.All.SendAsync("sendToAll", employerId, message);
        }
        public async Task PrivateSendMessage(string jobTitle, string employer, string student, string from, string message)
        {
            await Clients.All.SendAsync("sendToAll", new
            {
                jobTitle,
                employer,
                student,
                from,
                message,
                date = DateTime.Now
            });
        }


        private string GetFullName(int user_id)
        {

            string name = string.Empty;

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var user = dbContext.Profiles.FirstOrDefault(a => a.UserId == user_id);

                if (user != null) name = user.FirstName + " " + user.LastName;
            }

            return name;
        }
    }
}
