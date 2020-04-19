using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobDTO : BaseEntity
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public int EmployerId { get; set; }
        public int CategoryId { get; set; }
        public string EmployerEmail { get; set; }
        public string CategoryName { get; set; }
        public string Base64Photo { get; set; }
    }
}
