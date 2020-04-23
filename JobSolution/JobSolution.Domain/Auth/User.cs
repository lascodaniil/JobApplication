using JobSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobSolution.Domain.Auth
{
    public class User : IdentityUser<int>
    {

        public virtual Employer Employer{ get; set; }
        public virtual Student Student { get; set; }
    }
}
