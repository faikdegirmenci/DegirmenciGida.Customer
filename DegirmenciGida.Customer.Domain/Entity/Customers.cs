using Persistence.Repositories;

namespace DegirmenciGida.Customer.Domain
{
    public class Customers:BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public List<long> Orders { get; set; }
    }
}
