using JobSolution.Domain.Entities;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Interfaces;
using System.Threading.Tasks;

namespace JobSolution.Services.Concrete
{
    public class ServiceImage : IServiceImage
    {

        private readonly IRepositoryImage _repositoryImage;
        public ServiceImage(IRepositoryImage repositoryImage)
        {
            _repositoryImage = repositoryImage;
        }


        public int GetIdInsertedImage(string imagePath)
        {
            Image image = new Image() { Path = imagePath };
             
            return _repositoryImage.Add(image);
        }

        
    }
}
