using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
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
        private readonly IMapper mapper;

        public ImagesController(IImagesRepository repository, ICloudStorage cloudStorage, IMapper mapper)
        {
            this.repository = repository;
            this.cloudStorage = cloudStorage;
            this.mapper = mapper;
        }

        //GET api/images
        [HttpGet]
        public ActionResult<IEnumerable<Image>> GetAllImages()
        {
            var imageItems = repository.GetAllImages();
            return Ok(imageItems);
        }

        //GET api/images/{id}
        [HttpGet("{id}", Name = "GetImageById")]
        public ActionResult<Image> GetImageById(int id)
        {
            var imageItem = repository.GetImageById(id);

            if(imageItem == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            if(image == null)
            {
                return ValidationProblem();
            }

            string imageName = image.FileName;
            var imageUrl = await cloudStorage.UploadFileAsync(image, imageName);

            var imageModel = mapper.Map<Image>( new Image { Url = imageUrl, Name = imageName });
            repository.UploadImage(imageModel);

            return CreatedAtRoute(nameof(GetImageById), new { imageModel.Id }, imageModel);

        }
    }
}