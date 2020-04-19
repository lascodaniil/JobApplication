
using System.Collections.Generic;

namespace JobSolution.Domain.Entities
{
    public class Employer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public ICollection<Job> Job { get; set; }
 
    }
}
