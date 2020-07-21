using AutoMapper;
using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CatApi.API.Controllers.Tests
{
    public class ImagesControllerTests
    {
        [Fact]
        public void GetAllImages_ReturnsOkObjectResultWithListOfImages()
        {
            // Arrange
            var mockRepo = new Mock<IImagesRepository>();
            mockRepo.Setup(repo => repo.GetAllImages()).Returns(GetTestImages());

            var mockGCS = new Mock<ICloudStorage>();
            var mockMapper = new Mock<IMapper>();

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

    }
}