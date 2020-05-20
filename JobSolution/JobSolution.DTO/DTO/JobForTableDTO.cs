using JobSolution.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobSolution.DTO.DTO
{
    public class JobForTableDTO
    {
        public int JobId { get; set; }
        [StringLength(30, ErrorMessageResourceName = "Maximum length is 30")]
        public string Title { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string TypeJob { get; set; }
        public float Salary { get; set; }
        public string Contact { get; set; }
        public string Employer { get; set; }
        public DateTime? FinishedOn { get; set; }
        public DateTime ? PublishedOn { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int TypeJobId { get; set; }
        public int ImageId{get;set;}

        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }

    }
}
