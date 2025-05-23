using CustomerManagement.Models;

namespace CustomerManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = [];
        private static int _id = 1;

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public int AddCustomer(Customer customer)
        {
            customer.Id = _id;
            _customers.Add(customer);
            _id++;
            return customer.Id;
        }

        public bool RemoveCustomer(int id)
        {
            var customerToRemove = _customers.FirstOrDefault(c => c.Id == id);

            if (customerToRemove != null)
            {
                _customers.Remove(customerToRemove);
                return true;
            }

            return false;
        }
    }
}
