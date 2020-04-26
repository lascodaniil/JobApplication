using JobSolution.Domain.Entities;
using System;

namespace JobSolution.DTO.DTO
{
    public class EmployerPofileDTO : BaseEntity
    {
        public string Email { get; set; }
        public string Base64Photo { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

}
