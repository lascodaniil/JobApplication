
using JobSolution.Domain.Auth;
using System;
using System.Collections.Generic;

namespace JobSolution.Domain.Entities
{
    public class Job : BaseEntity
    {
        
        public int CategoryId { get; set; }
        public string Title { get; set; } 
        public string City { get; set; } 
        public string Contact { get; set; } 
        public DateTime? PostDate { get; set; } = DateTime.Now; 
        public DateTime? EndDate { get; set; } 
        public string Base64Photo { get; set; } 
        public float Salary { get; set; }
        public Categories Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
