using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.SignalR.Interfaces
{
    public interface IChat
    {
        Task SendMessage(string jwtToken, int employerId, string message);
        Task JoinRoom(int employerId, string jwtToken);
        Task LeaveRoom(int employerId, string jwtToken);
        Task<bool> IsEmployer(int employerId, string jwt);
        
    }
}
