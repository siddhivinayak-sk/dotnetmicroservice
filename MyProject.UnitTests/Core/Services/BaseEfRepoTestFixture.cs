using System;
using System.Collections.Generic;
using Moq;
using MyProject.Core.Interfaces.Repositories;

using MyProject.Core.Models;
using MyProject.Infrastructure.Services;

namespace MyProject.UnitTests.Core.Services
{
    public class BaseEfRepoTestFixture
    {

        public AccountService AccountService;

        public CustomerService CustomerService;

        public Account Account;

        public Customer Customer;

        public BaseEfRepoTestFixture()
        {

            Account = new Account
            {

                AccId = 100,

                CusId = 100,

                AccName = "test data",

                AccBalance = "test data",

                Status = true

            };

            Customer = new Customer
            {

                CusId = 100,

                CusName = "test data",

                Address = "test data",

                ContactNo = "test data"

            };

            var accountRepository = new Mock<IAccountRepository>();

            accountRepository.Setup(x => x.GetAccount(100)).Returns(Account);

            accountRepository.Setup(x => x.DeleteAccount(100)).Returns(Account);

            accountRepository.Setup(x => x.CreateAccount(Account)).Returns(Account);

            accountRepository.Setup(x => x.UpdateAccount(Account)).Returns(Account);

            var customerRepository = new Mock<ICustomerRepository>();

            customerRepository.Setup(x => x.GetCustomer(100)).Returns(Customer);

            customerRepository.Setup(x => x.CreateCustomer(Customer)).Returns(Customer);

            AccountService = new AccountService(accountRepository.Object);

            CustomerService = new CustomerService(customerRepository.Object);

        }
    }
}
