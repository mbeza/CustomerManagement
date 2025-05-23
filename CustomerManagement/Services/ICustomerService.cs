using CustomerManagement.Models;

namespace CustomerManagement.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        int AddCustomer(Customer customer);
        bool RemoveCustomer(int id);
    }
}
