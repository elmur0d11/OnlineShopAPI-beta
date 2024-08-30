using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class BuyedProductsProfile : Profile
    {
        public BuyedProductsProfile()
        {
            CreateMap<BuyedProductCreatedDto, BuyedProduct>();

            CreateMap<BuyedProduct, BuyedProductReadDto>();
        }
    }
}
