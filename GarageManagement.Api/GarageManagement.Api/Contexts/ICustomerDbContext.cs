using GarageManagement.Data;

namespace GarageManagement.Api.Contexts
{
    public interface ICustomerDbContext
    {
        Task<bool> AddUser(CustomerDetail customer);
        Task<CustomerDetail> GetUser(String username);

        Task<bool> DeleteUser(string username);

        Task<bool> UpdateUser(CustomerDetail customer);

    }
}
