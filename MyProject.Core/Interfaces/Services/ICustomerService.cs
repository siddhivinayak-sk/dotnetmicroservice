using System;
using System.Collections.Generic;

using MyProject.Core.Models;

namespace MyProject.Core.Interfaces.Services
{
    public interface ICustomerService
    {

        Customer GetCustomer(int cusId);

        Customer CreateCustomer(Customer customer);

    }
}
