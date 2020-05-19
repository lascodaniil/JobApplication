using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Database;
using JobSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{

    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {   
        public ProfileRepository(AppDbContext context) : base(context){ }

        public async Task<Profile> GetAuthUserProfile(int UserId)
        {
            var User = await _dbContext.Profiles.FirstOrDefaultAsync(x => x.UserId == UserId);
                return User;
        }

        public async Task UpdateProfile(Profile profile)
        {
             _dbContext.Profiles.Update(profile);
            await _dbContext.SaveChangesAsync();
        }
    }
}
