using Microsoft.AspNetCore.Http;

namespace CatApi.ViewModels
{
    public class ImageViewModel
    {
        public IFormFile file { get; set; }
    }
}
