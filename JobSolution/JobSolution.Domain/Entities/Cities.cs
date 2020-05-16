using System.Collections.Generic;

namespace JobSolution.Domain.Entities
{
    public class Cities : BaseEntity
    {
        public string City { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
