using DapperDog.Data;
using DapperDog.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public CustomerDetail GetCustomerDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(m => m.CustomerId == id);
                return new CustomerDetail
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    City = customer.City,
                    State = customer.State,
                    Zipcode = customer.Zipcode
                };
            }
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newCustomer = new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode
                };

                ctx.Customers.Add(newCustomer);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers.Select(m => new CustomerListItem
                {
                    CustomerId = m.CustomerId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Address = m.Address,
                    City = m.City,
                    State = m.State,
                    Zipcode = m.Zipcode
                });

                return query.ToArray();
            }

        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(m => m.CustomerId == model.CustomerId);
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Address = model.Address;
                customer.City = model.City;
                customer.State = model.State;
                    customer.Zipcode = model.Zipcode;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Customers.Any(m => m.CustomerId == customerId))
                    return false;

                var model =
                    ctx
                    .Customers
                    .Single(m => m.CustomerId == customerId);

                ctx.Customers.Remove(model);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
