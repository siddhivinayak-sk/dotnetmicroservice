using System;
using System.Collections.Generic;

using MyProject.Core.Models;

namespace MyProject.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {

        Customer GetCustomer(int cusId);

        Customer CreateCustomer(Customer customer);

    }
}
