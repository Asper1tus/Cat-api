using AutoMapper;
using CatApi.API.Controllers;
using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CatApi.API.Tests.Controllers
{
    public class ImagesControllerTests
    {
        readonly Mock<IImagesRepository> mockRepo;
        readonly Mock<ICloudStorage> mockGCS;
        readonly Mock<IMapper> mockMapper;

        public ImagesControllerTests()
        {
            mockRepo = new Mock<IImagesRepository>();
            mockGCS = new Mock<ICloudStorage>();
            mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void GetAllImages_ReturnsOkObjectResult_WithListOfImages()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetAllImages()).Returns(GetTestImages());
            var controller = new ImagesController(mockRepo.Object, mockGCS.Object, mockMapper.Object);

            // Act
            var result = controller.GetAllImages();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Image>>(
                okObjectResult.Value);
            Assert.Equal(GetTestImages().Count, model.Count());

        }

        private List<Image> GetTestImages()
        {
            var images = new List<Image>
            {
                new Image{Id = 0, Url = "google.com/image1", Name = "image1" },
                new Image{Id = 1, Url = "google.com/image2", Name = "image2" },
                new Image{Id = 2, Url = "google.com/image3", Name = "image3" },
            };

            return images;
        }

        [Fact]
        public void GetImageById_ReturnsNotFoundResult_WhenUserNotFound()
        {
            // Arrange
            int testImageId = 5;
            mockRepo.Setup(repo => repo.GetImageById(testImageId))
                .Returns(null as Image);
            var controller = new ImagesController(mockRepo.Object, mockGCS.Object, mockMapper.Object);

            // Act
            var result = controller.GetImageById(testImageId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetImageById_ReturnsokObjectResult_WithImage()
        {
            // Arrange
            int testImageId = 1;
            var testImage = new Image { Id = 1, Url = "google.com/image2", Name = "image2" };
            mockRepo.Setup(repo => repo.GetImageById(testImageId))
                .Returns(testImage);

            var controller = new ImagesController(mockRepo.Object, mockGCS.Object, mockMapper.Object);

            // Act
            var result = controller.GetImageById(testImageId);
          
            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(testImage, okObjectResult.Value);
        }
    }
}
