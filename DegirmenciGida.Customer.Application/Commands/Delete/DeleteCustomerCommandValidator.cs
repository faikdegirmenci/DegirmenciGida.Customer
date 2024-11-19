using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegirmenciGida.Customer.Application.Commands.Delete
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(c=>c.Id).NotEmpty();
        }
    }
}
