using AutoMapper;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IServiceImage _serviceImage;

        public ProfileService(IProfileRepository profileRepository, 
            IMapper mapper, 
            IHttpContextAccessor context, 
            IHostingEnvironment hostingEnvironment,
            IServiceImage serviceImage)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _serviceImage = serviceImage;
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
            var userProfile = await _profileRepository.GetAuthUserProfile(UserId);
            Domain.Entities.Profile profile = new Domain.Entities.Profile();


            IFormFile file = userRegisterDto.Image;
            string fullPath = null;
            var imageId = 0;

            if (file != null)
            {
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }
                string newPath = Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                imageId = _serviceImage.GetIdInsertedImage(fullPath);
                userProfile.ImageId = imageId;
            }

            userProfile.FirstName = userRegisterDto.FirstName;
            userProfile.LastName = userRegisterDto.LastName;
            userProfile.PhoneNumber = userRegisterDto.PhoneNumber;
            userProfile.DateOfBirth = userRegisterDto.DateOfBirth;
            userProfile.Email = userProfile.Email;

            await _profileRepository.UpdateProfile(userProfile);
        }
    }
}
