using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobDTO 
    {
        public int JobId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Employer { get; set; }
        public string City { get; set; }
        public DateTime? PublishedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
        public DateTime? EnrolledDate { get; set; }
        public string Base64Photo { get; set; }
        public string Contact { get; set; }
        public float Salary { get; set; }
        public string Description { get; set; }
    }
}
