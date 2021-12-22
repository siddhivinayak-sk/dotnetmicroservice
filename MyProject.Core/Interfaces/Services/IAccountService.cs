using System;
using System.Collections.Generic;

using MyProject.Core.Models;

namespace MyProject.Core.Interfaces.Services
{
    public interface IAccountService
    {

        Account GetAccount(int accId);

        Account DeleteAccount(int accId);

        Account CreateAccount(Account account);

        Account UpdateAccount(Account account);

    }
}
