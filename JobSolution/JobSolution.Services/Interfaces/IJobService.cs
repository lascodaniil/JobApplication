using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;


namespace JobSolution.Services.Interfaces
{
    public interface IJobService
    {

        IEnumerable<Job> GetAll();
        Job GetByID(int id);
        void Add(Job entity);
        void Update(Job entity);
        void Remove(int Id);
        bool SaveAll();
    }
}
