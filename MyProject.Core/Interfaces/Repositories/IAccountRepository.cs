using System;
using System.Collections.Generic;

using MyProject.Core.Models;

namespace MyProject.Core.Interfaces.Repositories
{
    public interface IAccountRepository
    {

        Account GetAccount(int accId);

        Account DeleteAccount(int accId);

        Account CreateAccount(Account account);

        Account UpdateAccount(Account account);

    }
}
