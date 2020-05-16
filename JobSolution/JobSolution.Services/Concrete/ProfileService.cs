using AutoMapper;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;

        public ProfileService(IProfileRepository profileRepository, IMapper mapper, IHttpContextAccessor context)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _context = context;
        }


        public async Task<ProfileDTO> GetAuthProfile()
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            var UserProfile = await _profileRepository.GetAuthUserProfile(UserId);
            return _mapper.Map<ProfileDTO>(UserProfile);
        }

        public async Task UpdateProfile(UserRegisterDto userRegisterDto)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            



        }
    }
}
