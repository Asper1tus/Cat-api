using System.ComponentModel.DataAnnotations;

namespace CatApi.DAL.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int Width { get; set; }

        public int Heigth { get; set; }
    }

}
