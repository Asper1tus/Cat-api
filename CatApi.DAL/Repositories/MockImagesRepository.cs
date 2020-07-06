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
                new Image{Id = 0, Url = "google.com/image1", Heigth = 100, Width = 200 },
                new Image{Id = 1, Url = "google.com/image2", Heigth = 300, Width = 400 },
                new Image{Id = 2, Url = "google.com/image3", Heigth = 500, Width = 600 },
            };

            return images;

        }

        public Image GetImageById(int id)
        {
            return new Image {Id = 0, Url = "google.com/image1", Heigth = 100, Width = 200 };
        }

        public Image GetRandomImage()
        {
            return new Image {Id = 1, Url = "google.com/image2", Heigth = 300, Width = 400 };
        }
    }
}
