using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.DTO.DTO
{
    public class StudentJobsDto
    {
        public string FirstName { get; set; }
        public string Email { get; set; }

        public IList<StudentJobDTO> Jobs { get; set; }
    }
}
