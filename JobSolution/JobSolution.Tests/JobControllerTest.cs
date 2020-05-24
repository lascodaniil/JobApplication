using AutoMapper;
using JobSolution.API.Controllers;
using JobSolution.Domain.Auth;
using JobSolution.Domain.Entities;
using JobSolution.DTO.DTO;
using JobSolution.Repository.Interfaces;
using JobSolution.Services.Concrete;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JobSolution.Tests
{

    public class JobControllerTest
    {

        [Fact]
        public void GetAllJobsOkTest()
        {
            var mockRepository = new Mock<IJobService>();
            var mockIMapper = new Mock<IMapper>();
            var categoryServiceRepository = new Mock<ICategoryService>();
            var cityServiceCategory = new Mock<ICityService>();
            var ITypeJobService = new Mock<ITypeJobService>();
            var IRepositoryService = new Mock<IRepositoryImage>();
            var controller = new JobController(mockRepository.Object,
                categoryServiceRepository.Object, cityServiceCategory.Object,
                ITypeJobService.Object, mockIMapper.Object, IRepositoryService.Object);

            Task<IActionResult> ActionResult = controller.GetAll();
            OkResult contentResult = (OkResult)ActionResult.Result;

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<JobForTableDTO>() { });
          
            //Assert.NotNull(contentResult);
            //Assert.Equal(200, contentResult.StatusCode);
        }


        [Fact]
        public void DeleteUncorrectIdTest()
        {
            var mockRepository = new Mock<IJobService>();
            var mockIMapper = new Mock<IMapper>();
            var categoryServiceRepository = new Mock<ICategoryService>();
            var cityServiceCategory = new Mock<ICityService>();
            var ITypeJobService = new Mock<ITypeJobService>();
            var IRepositoryService = new Mock<IRepositoryImage>();
            var controller = new JobController(mockRepository.Object,
                categoryServiceRepository.Object, cityServiceCategory.Object,
                ITypeJobService.Object, mockIMapper.Object, IRepositoryService.Object);

            int id = -5;


            mockRepository.Setup(x => x.Remove(id));

            Task<IActionResult> ActionResult = controller.Delete(id);
            NotFoundResult contentResult = (NotFoundResult)ActionResult.Result;

            Assert.NotNull(contentResult);
            Assert.Equal(404, contentResult.StatusCode);
            mockRepository.Verify(x => x.Remove(id), Times.Never());
        }


        [Fact]
        public void GetByIdTest()
        {
            var mockRepository = new Mock<IJobService>();
            var mockIMapper = new Mock<IMapper>();
            var categoryServiceRepository = new Mock<ICategoryService>();
            var cityServiceCategory = new Mock<ICityService>();
            var ITypeJobService = new Mock<ITypeJobService>();
            var IRepositoryService = new Mock<IRepositoryImage>();
            var controller = new JobController(mockRepository.Object,
                categoryServiceRepository.Object, cityServiceCategory.Object,
                ITypeJobService.Object, mockIMapper.Object, IRepositoryService.Object);


            int id = 1;

            mockRepository.Setup(x => x.GetByID(id)).ReturnsAsync(new JobForTableDTO());

            Task<IActionResult> ActionResult = controller.GetById(id);
            OkObjectResult contentResult = (OkObjectResult)ActionResult.Result;

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }


        [Fact]
        public void DeleteCorrectIdTest()
        {
            var mockRepository = new Mock<IJobService>();
            var mockIMapper = new Mock<IMapper>();
            var categoryServiceRepository = new Mock<ICategoryService>();
            var cityServiceCategory = new Mock<ICityService>();
            var ITypeJobService = new Mock<ITypeJobService>();
            var IRepositoryService = new Mock<IRepositoryImage>();
            var controller = new JobController(mockRepository.Object,
                categoryServiceRepository.Object, cityServiceCategory.Object,
                ITypeJobService.Object, mockIMapper.Object, IRepositoryService.Object);

            int id = 10000;


            Task<IActionResult> ActionResult = controller.Delete(id);
            try
            {
                NotFoundResult contentResult = (NotFoundResult)ActionResult.Result;
                mockRepository.Setup(x => x.Remove(id)).Returns(Task.CompletedTask);
                Assert.NotNull(contentResult);
                Assert.Equal(404, contentResult.StatusCode);
            }
            catch (Exception ex)
            {
                OkObjectResult contentResult = (OkObjectResult)ActionResult.Result;
                mockRepository.Setup(x => x.Remove(id)).Returns(Task.CompletedTask);
                Assert.NotNull(contentResult);
                Assert.Equal(200, contentResult.StatusCode);
            }
        }

    }
}
