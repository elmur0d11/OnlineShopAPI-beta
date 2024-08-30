using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<ProductCreatedDto, Product>();

            CreateMap<Product, ProductReadDto>();

            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
