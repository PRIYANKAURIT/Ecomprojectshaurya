using Dapper;
using Ecomprojectshaurya.Context;
using Ecomprojectshaurya.Model;
using Ecomprojectshaurya.Repository.Interface;

namespace Ecomprojectshaurya.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Customer> Login(DtoLogin log)
        {
            var query = "SELECT * FROM customer where cust_email=@cust_email";
            using (var connection = _context.CreateConnection())
            {
                var customer = await connection.QueryFirstOrDefaultAsync<Customer>(query, new { cust_email = log.cust_email });
                return customer;
            }
        }

        public async Task<int> Registration(gender gen,DtoRegistration reg)
        {
            
            var query = "insert into customer(cust_id,cust_name, cust_mobile, cust_email,password, cust_gender)" +
                        "values(@cust_id,@cust_name, @cust_mobile, @cust_email, @password, @cust_gender)";
            using (var connection = _context.CreateConnection())
            {
               var result = await connection.ExecuteAsync(query, reg);
                return result;
            }
        }

        public async Task<int> UpdateCustomer(gender gen,Customer cust)
        {

            var query = "update customer set cust_name=@cust_name,cust_mobile=@cust_mobile,cust_email=@cust_email,password =@password,cust_gender=@cust_gender,  cust_billing_address_id=@cust_billing_address_id,cust_shipping_address_id=@cust_shipping_address_id,cust_account_created=@cust_account_created,cust_is_deleted=@cust_is_deleted where cust_id=@cust_id";
                        

            using (var connection = _context.CreateConnection())
            {
                 var result=await connection.ExecuteAsync(query,cust);
                 return result;
            }
        }

        public async Task<IEnumerable<Customer>> viewcustomers()
        {
            var query = "SELECT * FROM customer";
            using (var connection = _context.CreateConnection())
            {
                var customer = await connection.QueryAsync<Customer>(query);
                return customer.ToList();
            }
        }
    }
}
