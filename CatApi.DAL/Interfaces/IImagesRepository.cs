using CatApi.DAL.Models;
using System.Collections.Generic;

namespace CatApi.DAL.Interfaces
{
    public interface IImagesRepository
    {
        public IEnumerable<Image> GetAllImages();
        public Image GetRandomImage();
        public Image GetImageById(int id);
        public void UploadImage(Image image);
    }
}
