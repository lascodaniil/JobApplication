using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
