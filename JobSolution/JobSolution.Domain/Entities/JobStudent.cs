using JobSolution.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSolution.Domain.Entities
{
    public class JobStudent : BaseEntity
    {
        public int JobId { get; set; }
        public int? UserId { get; set; }
        public virtual Job Job { get; set; }
        public virtual User User { get; set; }
    }
}
