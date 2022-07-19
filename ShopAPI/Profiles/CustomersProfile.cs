using AutoMapper;
using ShopAPI.Dtos;
using ShopAPI.Models;

namespace ShopAPI.Profiles{

    public class CustomersProfile : Profile{
        public CustomersProfile(){
            CreateMap<CustomerCreateDto, Customer>();
        }
    }
}