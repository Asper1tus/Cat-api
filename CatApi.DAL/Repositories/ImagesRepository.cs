using CatApi.DAL.EF;
using CatApi.DAL.Interfaces;
using CatApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatApi.DAL.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ApplicationContext context;

        public ImagesRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return context.Images.ToList();
        }

        public Image GetImageById(int id)
        {
            return context.Images.FirstOrDefault(p => p.Id == id);
        }

        public Image GetRandomImage()
        {
            return context.Images.OrderBy(o => Guid.NewGuid()).First();
        }

        public void UploadImage(Image image)
        {
            context.Add(image);
            context.SaveChanges();
        }
    }
}
