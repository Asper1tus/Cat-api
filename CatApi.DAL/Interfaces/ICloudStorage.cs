using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CatApi.DAL.Interfaces
{
    public interface ICloudStorage
    {
        Task<string> UploadFileAsync(IFormFile imageFile, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
