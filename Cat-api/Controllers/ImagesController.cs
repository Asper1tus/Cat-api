using System.Collections.Generic;
using System.Threading.Tasks;
using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
using CatApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesRepository repository;
        private readonly ICloudStorage cloudStorage;

        public ImagesController(IImagesRepository repository, ICloudStorage cloudStorage)
        {
            this.repository = repository;
            this.cloudStorage = cloudStorage;
        }

        //GET api/images
        [HttpGet]
        public ActionResult<IEnumerable<Image>> GetAllImages()
        {
            var imageItems = repository.GetAllImages();
            return Ok(imageItems);
        }

        //GET api/images/{id}
        [HttpGet("{id}")]
        public ActionResult<Image> GetImageById(int id)
        {
            var imageItem = repository.GetImageById(id);
            return Ok(imageItem);
        }

        //GET api/images/random
        [Route("random")]
        [HttpGet]
        public ActionResult<Image> GetRandomImage()
        {
            var imageItem = repository.GetRandomImage();
            return Ok(imageItem);
        }

        //POST api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] ImageViewModel uploadedImage)
        {
            if (uploadedImage != null)
            {
                string imageName = uploadedImage.file.FileName;
                var imageUrl = await cloudStorage.UploadFileAsync(uploadedImage.file, imageName);

                Image imageItem = new Image { Url = imageUrl, Name = imageName };
                repository.UploadImage(imageItem);

                return Ok(imageItem);
            }

            return BadRequest();

        }
    }
}