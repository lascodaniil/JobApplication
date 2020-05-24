using JobSolution.Domain;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobSolution.Services.Interfaces
{
    public interface IAuthService
    {
        Task<IActionResult> AddUser(UserRegisterDto userRegisterDto);
        Task<IActionResult> GetToken(UserForLoginDto userLoginDto);
    }
}
