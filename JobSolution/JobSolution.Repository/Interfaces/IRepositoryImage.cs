using JobSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JobSolution.Repository.Interfaces
{
    public interface IRepositoryImage
    {
        Task<string> GetImageById(int ImageId);
        Task<FileStream> GetImageStreamById(int ImageId);
        Task Update(int ImageId, string Url);
        Task Delete(int imageId);
        int Add(Image image);
    }
}
