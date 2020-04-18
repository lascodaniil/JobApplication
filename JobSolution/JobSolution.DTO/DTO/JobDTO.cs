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

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Contact cannot be longer than 50 characters.")]
        public string Contact { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string Base64Photo { get; set; }
    }
}
