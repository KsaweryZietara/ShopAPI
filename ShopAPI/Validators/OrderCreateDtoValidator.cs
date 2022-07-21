using FluentValidation;
using ShopAPI.Dtos;

namespace ShopAPI.Validators{

    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>{
        public OrderCreateDtoValidator(){
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.Status).Length(0, 40);
            RuleFor(x => x.OrderDate).NotNull();
            RuleFor(x => x.Products).NotNull();
            RuleFor(x => x.Customer).NotNull();
        }
    }
}