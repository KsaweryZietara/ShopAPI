using AutoMapper;
using ShopAPI.Dtos;
using ShopAPI.Models;

namespace ShopAPI.Profiles{

    public class OrdersProfile : Profile{
        public OrdersProfile(){
            CreateMap<OrderCreateDto, Order>();
        }
    }
}