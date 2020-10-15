using AutoMapper;
using CatApi.DAL.Models;
using CatApi.Dtos;

namespace CatApi.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<ImageCreateDto, Image>();
        }
    }
}
