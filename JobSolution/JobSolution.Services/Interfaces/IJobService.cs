using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using JobSolution.Repository;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using AutoMapper;

namespace JobSolution.Services.Interfaces
{
    public interface IJobService
    {
        Task<IList<JobDTO>> GetAll();
        Task<JobDTO> GetByID(int JobId);
        Task Add(JobForPostdDTO JobDTO);
        Task Update(JobForPostdDTO JobDTO,int id);
        Task Remove(int JobId);
        Task<IList<JobDTO>> GetJobsByCategory(string Category);
        Task<PaginatedResult<JobGridRowDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper);
        Task<PaginatedResult<JobGridRowDTO>> GetJobsForEmployer(PagedRequest pagedRequest, IMapper mapper);
    }
}