using Ecomprojectshaurya.Model;

namespace Ecomprojectshaurya.Repository.Interface
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> viewcustomers();
        public Task<int> Registration(gender gen,DtoRegistration reg);
        public Task<Customer> Login(DtoLogin log);
        public Task<int> UpdateCustomer(gender gen,Customer cust);
    }
}
