using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
using System.Collections.Generic;

namespace CatApi.DAL.Repositories
{
    public class MockImagesRepository : IImagesRepository
    {
        public IEnumerable<Image> GetAllImages()
        {
            var images = new List<Image>()
            {
                new Image{Id = 0, Url = "google.com/image1", Name = "image1" },
                new Image{Id = 1, Url = "google.com/image2", Name = "image2" },
                new Image{Id = 2, Url = "google.com/image3", Name = "image3" },
            };

            return images;

        }

        public Image GetImageById(int id)
        {
            return new Image {Id = 0, Url = "google.com/image1", Name = "image1" };
        }

        public Image GetRandomImage()
        {
            return new Image {Id = 1, Url = "google.com/image2", Name = "image2" };
        }

        public void UploadImage(Image image)
        {
            throw new System.NotImplementedException();
        }
    }
}
