using DegirmenciGida.Customer.Domain;
using Persistence.Repositories;

namespace DegirmenciGida.Customer.Application
{
    public interface ICustomerService : IAsyncRepository<Customers, Guid>
    {
    }
}
