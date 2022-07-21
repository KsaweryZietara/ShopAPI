using FluentValidation;
using ShopAPI.Dtos;

namespace ShopAPI.Validators{

    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>{
        public ProductCreateDtoValidator(){
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(0, 30);
            RuleFor(x => x.Category).NotNull();
            RuleFor(x => x.Category).Length(0, 40);
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}