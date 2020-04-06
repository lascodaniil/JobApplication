using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class StudentDTO : BaseEntity
    {
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "FirstName cannot be longer than 255 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "LastName cannot be longer than 255 characters.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Email format is incorect")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "University title cannot be longer than 255 characters.")]
        public string University { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
