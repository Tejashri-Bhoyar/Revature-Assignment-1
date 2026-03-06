using FluentValidation;

namespace DataAccessLayer;

public class CreateCustomerDTOValidator 
    : AbstractValidator<CreateCustomerDTO>
{
    public CreateCustomerDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Age)
            .GreaterThan(0);
    }
}