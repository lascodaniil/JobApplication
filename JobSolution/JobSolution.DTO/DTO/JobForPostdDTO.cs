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
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public float Salary { get; set; }
        public string Base64Photo { get; set; }
        public string Contact { get; set; }
    }
}
