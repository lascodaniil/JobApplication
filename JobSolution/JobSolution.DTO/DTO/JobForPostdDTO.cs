using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobForPostdDTO
    {
        [Required]
        [StringLength(200, MinimumLength =3)]
        public string Title { get; set; }
        [StringLength(int.MaxValue, MinimumLength =5)]
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime StopDate { get; set; }
        [Required]
        public float Salary { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string Base64Photo { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
    }
}
