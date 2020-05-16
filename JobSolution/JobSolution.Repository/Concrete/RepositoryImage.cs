using JobSolution.Domain.Entities;
using JobSolution.Infrastructure.Database;
using JobSolution.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Concrete
{
    public class RepositoryImage : Repository<Image>, IRepositoryImage
    {
        public RepositoryImage(AppDbContext context) : base(context) { }

        public int Add(Image image)
        {
            Image img = new Image();
            img.Path = image.Path;

            var imageAdded = new Image()
            {
                Path = image.Path,
            };

             _dbContext.Images.Add(imageAdded);
            
             _dbContext.SaveChanges();

            return imageAdded.Id;
        }

        public async Task Delete(int imageId)
        {
            var row = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == imageId);
            _dbContext.Images.Remove(row);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> GetImageById(int ImageId)
        {
            var row = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == ImageId);
            return row.Path;
        }

        public async Task<FileStream> GetImageStreamById(int ImageId)
        {
            var row = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == ImageId);
            FileStream fileStream = new FileStream(row.Path, FileMode.Open);

            return fileStream;
        }

        public async Task Update(int ImageId, string Url)
        {
            var row = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == ImageId);
            row.Path = Url;
           await  _dbContext.SaveChangesAsync();
        }
    }
}
