
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string University { get; set; }
        public string Base64Photo { get; set; }
        public int NumberOfJobs { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegisterDate { get; private set; } = DateTime.Now;
        public ICollection<StudentJob> StudentJobs { get; set; }
    }
}
