using System.Collections.Generic;
using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesRepository repository;

        public ImagesController(IImagesRepository repository)
        {
            this.repository = repository;
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
    }
}