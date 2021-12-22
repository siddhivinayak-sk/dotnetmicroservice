using System;
using System.Collections.Generic;
using MyProject.Core.Interfaces.Services;
using MyProject.Core.Interfaces.Repositories;

using MyProject.Core.Models;

namespace MyProject.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccount(int accId)
        {
            return _accountRepository.GetAccount(accId);
        }

        public Account DeleteAccount(int accId)
        {
            return _accountRepository.DeleteAccount(accId);
        }

        public Account CreateAccount(Account account)
        {
            return _accountRepository.CreateAccount(account);
        }

        public Account UpdateAccount(Account account)
        {
            return _accountRepository.UpdateAccount(account);
        }

    }
}
