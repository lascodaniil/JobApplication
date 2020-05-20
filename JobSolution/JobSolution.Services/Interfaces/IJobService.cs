using System.Collections.Generic;
using System.Threading.Tasks;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using AutoMapper;

namespace JobSolution.Services.Interfaces
{
    public interface IJobService
    {
        Task<IList<JobForTableDTO>> GetAll();
        Task<JobForTableDTO> GetByID(int JobId);
        Task Add(JobForTableDTO JobDTO);
        Task Update(JobForTableDTO jobDTO, int id);
        Task Remove(int JobId);
        Task<IList<JobForTableDTO>> GetByType(int TypeId);
        Task AddedJobByStudent(int id);
        Task DeleteJobStudent(int id);
        Task<PaginatedResult<JobForTableDTO>> GetPagedData(PagedRequest pagedRequest, IMapper mapper);
        Task<PaginatedResult<JobForTableDTO>> GetJobsForEmployer(PagedRequest pagedRequest, IMapper mapper);
        Task<PaginatedResult<JobForTableDTO>> GetJobsForStudent(PagedRequest pagedRequest, IMapper mapper);
        Task<PaginatedResult<JobForViewDTO>> GetJobsByType(PagedRequest pagedRequest, IMapper mapper, int typeId);
        Task<PaginatedResult<JobForViewDTO>> GetJobsByJobTypeId(PagedRequest pagedRequest, IMapper mapper, int JobTypeId);
    }
}