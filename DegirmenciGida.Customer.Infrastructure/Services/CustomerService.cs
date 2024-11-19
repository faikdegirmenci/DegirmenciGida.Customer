using DegirmenciGida.Customer.Application;
using DegirmenciGida.Customer.Domain;
using Persistence.Repositories;

namespace DegirmenciGida.Customer.Infrastructure
{
    public class CustomerService : EfRepositoryBase<Customers,Guid,CustomerDbContext>, ICustomerService
    {
        public CustomerService(CustomerDbContext context) : base(context)
        {
        }
    }
}
