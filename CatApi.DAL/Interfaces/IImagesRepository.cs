using CatApi.DAL.Models;

namespace CatApi.DAL.Interfaces
{
    public interface IImagesRepository
    {
        Image GetRandomImage();

        Image GetImageById(int id);
    }
}
