using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class LikedProductsProfile : Profile
    {
        public LikedProductsProfile() 
        {
            CreateMap<LikedProductCreatedDto, LikedProduct>();

            CreateMap<LikedProduct, LikedProductReadDto>();
        }
    }
}
