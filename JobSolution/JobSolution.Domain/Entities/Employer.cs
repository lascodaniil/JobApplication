
using JobSolution.Domain.Auth;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSolution.Domain.Entities
{
    public class Employer : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; } 
        public virtual User User { get; set; }
        public ICollection<Job> Job { get; set; }

    }
}
