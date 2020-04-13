
using System;
using System.Collections.Generic;

namespace JobSolution.Domain.Entities
{
    public class Job : BaseEntity
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public Author Author { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Base64Photo { get; set; }
        public Categories Category { get; set; }
        public ICollection<StudentJob> StudentJobs { get; set; }
    }
}
