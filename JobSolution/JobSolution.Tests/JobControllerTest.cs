using AutoMapper;
using JobSolution.API.Controllers;
using JobSolution.DTO.DTO;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JobSolution.Tests
{
    public class JobControllerTest
    {
        [Fact]
        public void GetAllJobsOkTest()
        {
            // Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);

            // Check
            Task<IActionResult> ActionResult = controller.GetAll();
            OkObjectResult contentResult = (OkObjectResult)ActionResult.Result;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void GetByIdTest()
        {
            //Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            int id = 1;

            //Check
            Task<IActionResult> ActionResult = controller.GetById(id);
            OkObjectResult contentResult = (OkObjectResult)ActionResult.Result;

            //Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]

        public void DeleteCorrectIdTest()
        {
            //Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            int id = 1; // value

            //Check
            Task<IActionResult> ActionResult = controller.Delete(id);
            OkResult contentResult = (OkResult)ActionResult.Result;

            //Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void DeleteUncorrectIdTest()
        {
            //Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            int id = -5; // value

            //Check
            Task<IActionResult> ActionResult = controller.Delete(id);
            NotFoundResult contentResult = (NotFoundResult)ActionResult.Result;

            Assert.NotNull(contentResult);
            Assert.Equal(404, contentResult.StatusCode);
        }

        [Fact]
        public void PostCorrectModelTest()
        {
            //Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            var sendValue = new JobDTO() // value
            {
                Title = "test title",
                City = "test city",
                Contact = "test contact",
                AuthorId = 1,
                CategoryId = 1
            };

            //Check
            Task<IActionResult> ActionResult = controller.Post(sendValue);
            OkResult contentResult = (OkResult)ActionResult.Result;

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void UpdateCorrectModelTest()
        {
            //which is in a database
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            var sendValue = new JobDTO() // value
            {
                Title = "test title",
                City = "test city",
                Contact = "test contact",
                AuthorId = 1,
                CategoryId = 1,
                Id = 0
            };

            //Check
            Task<IActionResult> ActionResult = controller.Update(sendValue);
            OkResult contentResult = (OkResult)ActionResult.Result;

            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]

        public void UpdateUnсorrectModelTest()
        {
            //which is not in a database
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            var sendValue = new JobDTO() // value
            {
                Title = "test title not in table",
                City = "test city not in table",
                Contact = "test contact not in table",
                AuthorId = 5,
                CategoryId = 55,
                Id = 114
            };

            //Check
            Task<IActionResult> ActionResult = controller.Update(sendValue);
            NotFoundResult contentResult = (NotFoundResult)ActionResult.Result;

            Assert.NotNull(contentResult);
            Assert.Equal(404, contentResult.StatusCode);
        }
    }
}
