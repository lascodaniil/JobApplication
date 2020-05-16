using JobSolution.SignalR.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.SignalR.Concrete
{
    public class Chat : Hub, IChat
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<int, bool> _IsEmployerOnlineInGroup;

        public Chat(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            _IsEmployerOnlineInGroup = new Dictionary<int, bool>();
        }

        public async Task<bool> IsEmployer(int employerId, string jwt)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwt);
            return false;
        }

        public Task JoinRoom(int employerId, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task LeaveRoom(int employerId, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task SendMessage(string jwtToken, int employerId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
