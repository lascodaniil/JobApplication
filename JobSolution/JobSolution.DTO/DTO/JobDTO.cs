using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class JobDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Title cannot be longer than 255 characters.")]
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
    }
}
