using AutoMapper;
using JobSolution.API.Controllers;
using JobSolution.DTO.DTO;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
        public void DeleteCorrectIdTest()
        {
            //Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);
            int id = 10000; // value bigger the base contains or correct value

            //Check
            Task<IActionResult> ActionResult = controller.Delete(id);
            try
            {
                NotFoundResult contentResult = (NotFoundResult)ActionResult.Result;

                //Assert
                Assert.NotNull(contentResult);
                Assert.Equal(404, contentResult.StatusCode);
            }
            catch (Exception ex)
            {
                OkObjectResult contentResult = (OkObjectResult)ActionResult.Result;

                //Assert
                Assert.NotNull(contentResult);
                Assert.Equal(200, contentResult.StatusCode);
            }
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


            Task<IActionResult> ActionResult = controller.Update(sendValue);

            //Check

            try
            {
                NotFoundResult contentResult = (NotFoundResult)ActionResult.Result;

                Assert.NotNull(contentResult);
                Assert.Equal(404, contentResult.StatusCode);
            }
            catch (Exception ex)
            {
                //this case in a database then return ok result
                OkResult contentResult = (OkResult)ActionResult.Result;

                Assert.NotNull(contentResult);
                Assert.Equal(200, contentResult.StatusCode);

            }

        }
    }
}
