using AutoMapper;
using ShopAPI.Dtos;
using ShopAPI.Models;

namespace ShopAPI.Profiles{

    public class ProductsProfile : Profile{
        public ProductsProfile(){
            CreateMap<ProductCreateDto, Product>();
        }
    }
}