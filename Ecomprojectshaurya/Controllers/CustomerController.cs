using Ecomprojectshaurya.Model;
using Ecomprojectshaurya.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomprojectshaurya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpOptions]
        [Route("[action]")]
        public async Task<IActionResult> Login(DtoLogin log)
        {
            try
            {
                var customer = await _customerRepo.Login(log);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<IActionResult> viewcustomers()
        {
            try
            {
                var customer = await _customerRepo.viewcustomers();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("/[action]")]
        public async Task<IActionResult> Registration(gender gen, DtoRegistration reg)
        {
            try
            {
                var result = await _customerRepo.Registration(gen,reg);

                if (result == null)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Inserted Successfuly", result));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch]
        [Route("/[action]")]
        public async Task<IActionResult> UpdateCustomer(gender gen, Customer cust)
        {
            try
            {
                var result = await _customerRepo.UpdateCustomer(gen,cust);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Updated Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
