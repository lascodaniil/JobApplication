using AutoMapper;
using JobSolution.API.Controllers;
using JobSolution.Domain.Entities;
using JobSolution.Repository;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace JobSolution.Tests
{
    public class HomeControllerTests
    {   
        [Fact]
        public void GetAllJobsOkTest()
        {
            // Arrange
            var mockRepository = new Mock<IJobService>().Object;
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository, mockIMapper);

            // Assert
            Task<IActionResult> ActionResult = controller.GetAll();
            var contentResult = ActionResult.Result as OkObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public void GetAllJobsNotFound()
        {
            // Arrange
            IEnumerable<Job> jobs = null;

            var mockRepository = new Mock<IJobService>();
            var mockIMapper = new Mock<IMapper>().Object;
            var controller = new JobController(mockRepository.Object, mockIMapper);
            amockRepository.Setup(getjobs => getjobs.GetAll()).Returns(jobs);

            // Act
            Task<IActionResult> ActionResult = controller.GetAll();
            var contentResult = ActionResult.Result as NotFoundObjectResult;

            // Assert
            Assert.NotNull(contentResult);
            //Assert.Equal( 200, typeof(System.Web.Http.Results.NotFoundResult));
        }

        [Fact]
        public void GetJobById()
        {

        }








    }
}
