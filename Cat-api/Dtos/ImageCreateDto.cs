using System.ComponentModel.DataAnnotations;

namespace CatApi.Dtos
{
    public class ImageCreateDto
    {
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
