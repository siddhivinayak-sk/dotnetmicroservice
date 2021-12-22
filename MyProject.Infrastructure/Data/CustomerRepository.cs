using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Interfaces.Repositories;
using MyProject.Core.Models;

namespace MyProject.Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetCustomer(int cusId)
        {

            return _dbContext.Customer.Find(cusId);

        }

        public Customer CreateCustomer(Customer customer)
        {

            _dbContext.Add(customer);
            _dbContext.SaveChanges();

            return customer;

        }

    }
}
