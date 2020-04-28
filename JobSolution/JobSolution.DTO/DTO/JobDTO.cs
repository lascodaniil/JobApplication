using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobDTO : BaseEntity
    {
       
        public int UserId { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Contact { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public string CategoryName { get; set; }
        public string Base64Photo { get; set; }
        public float Salary { get; set; }
        public DateTime ? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
    }
}
