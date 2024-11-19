using FluentValidation;

namespace DegirmenciGida.Customer.Application.Commands.Create
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c=>c.Email).NotEmpty();
            RuleFor(c=>c.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(c=>c.LastName).NotEmpty().MinimumLength(2);
        }
    }
}
