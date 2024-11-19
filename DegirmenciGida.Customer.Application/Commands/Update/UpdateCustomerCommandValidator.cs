using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegirmenciGida.Customer.Application.Commands.Update
{
    public class UpdateCustomerCommandValidator:AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(u=>u.Email).NotEmpty();
            RuleFor(u=>u.Id).NotEmpty();
        }
    }
}
