using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegirmenciGida.Customer.Application.Queries.GetById
{
    public class GetCustomerByIdQueryValidator:AbstractValidator<GetCustomerByIdQuery>
    {
        public GetCustomerByIdQueryValidator()
        {
            RuleFor(g=>g.Id).NotEmpty();
        }
    }
}
