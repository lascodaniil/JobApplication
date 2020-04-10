
using System.Collections.Generic;

namespace JobSolution.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Job> Job { get; set; }
 
    }
}
