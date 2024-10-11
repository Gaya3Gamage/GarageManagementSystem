using GarageManagement.Data;
using Microsoft.AspNetCore.Mvc;
using GarageManagement.Api.Contexts;

namespace GarageManagement.Controller
{
    [Route("äpi/user")]
    [ApiController]
    public class AccountContoller : ControllerBase
    {
        private readonly ICustomerDbContext _customerDbContext;
        public AccountContoller(ICustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        [HttpGet]
        [Route("getUser")]
        public async Task<ActionResult> GetCustomer(string NID)
        {
            try
            {
                var customer = await _customerDbContext.GetUser(NID);
                if (customer == null)
                {
                    throw new Exception("data is null");
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult> AddUser([FromBody] CustomerDetail customer)
        {
            try
            {
                var result = await _customerDbContext.AddUser(customer);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }
        [HttpDelete]
        [Route("deleteUser")]
        public async Task<ActionResult> DeleteCustomer(string NID)
        {
            try
            {
                var result = await _customerDbContext.DeleteUser(NID);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }
        [HttpPut]
        [Route("updateUser")]
        public async Task<ActionResult> UpdateCustomer([FromBody] CustomerDetail customer)
        {
            try
            {
                var result = await _customerDbContext.UpdateUser(customer);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(false);
            }
        }
    }


}
