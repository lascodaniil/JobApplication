using AutoMapper;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class StudentJobService : IStudentJobService
    {

        private readonly IStudentJobRepository _studentJobRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;
        public StudentJobService(IStudentJobRepository studentJobRepository , IMapper mapper, IHttpContextAccessor httpContext)
        {
            _studentJobRepository = studentJobRepository;
            _mapper = mapper;
            _context = httpContext;
        }

        public async Task Add(int jobId)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
            await _studentJobRepository.Add(UserId, jobId);
        }

        public async Task Delete(int jobId)
        {
            var UserId = Convert.ToInt32(_context.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
           await  _studentJobRepository.Delete(UserId, jobId);
        }
    }
}
