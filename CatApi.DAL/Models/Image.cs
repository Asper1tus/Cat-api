using System.ComponentModel.DataAnnotations;

namespace CatApi.DAL.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Url { get; set; }
    }

}
