
using System;
using System.Collections.Generic;

namespace JobSolution.Domain.Entities
{
    public class Job : BaseEntity
    {
        public int EmployerId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } // Math lessons
        public string City { get; set; }// Michigan 
        public string Contact { get; set; } //  00054646456456
        public Employer Employer { get; set; } // amazon 
        public DateTime? PostDate { get; set; } // 01.01.2020
        public DateTime? EndDate { get; set; } // 01.02.2020
        public string Base64Photo { get; set; } 
        public float Salary { get; set; }
        public Categories Category { get; set; }// education, real estate
        public ICollection<StudentJob> StudentJobs { get; set; }
    }
}
