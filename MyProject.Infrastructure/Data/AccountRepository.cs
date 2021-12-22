using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyProject.Core.Interfaces.Repositories;
using MyProject.Core.Models;

namespace MyProject.Infrastructure.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account GetAccount(int accId)
        {

            return _dbContext.Account.Find(accId);

        }

        public Account DeleteAccount(int accId)
        {

            var account = _dbContext.Account.Find(accId);
            _dbContext.Account.Remove(account);
            _dbContext.SaveChanges();

            return null;

        }

        public Account CreateAccount(Account account)
        {

            _dbContext.Add(account);
            _dbContext.SaveChanges();

            return account;

        }

        public Account UpdateAccount(Account account)
        {

            _dbContext.Entry(account).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return account;

        }

    }
}
