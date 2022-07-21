using FluentValidation;
using ShopAPI.Dtos;

namespace ShopAPI.Validators{

    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>{
        public CustomerCreateDtoValidator(){
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).Length(0, 40);
            RuleFor(x => x.Tier).NotNull();
        }
    }
}