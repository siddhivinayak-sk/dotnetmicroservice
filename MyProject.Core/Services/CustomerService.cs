using System;
using System.Collections.Generic;
using MyProject.Core.Interfaces.Services;
using MyProject.Core.Interfaces.Repositories;

using MyProject.Core.Models;

namespace MyProject.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomer(int cusId)
        {
            return _customerRepository.GetCustomer(cusId);
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.CreateCustomer(customer);
        }

    }
}
