using System;
using System.Collections.Generic;
using System.Text;

namespace CatApi.DAL.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int Width { get; set; }

        public int Heigth { get; set; }
    }

}
