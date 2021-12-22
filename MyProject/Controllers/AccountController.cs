using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Interfaces.Services;

using MyProject.Core.Models;
using Microsoft.Extensions.Logging;
using System;

namespace MyProject.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet("/account/{accId}")]
        public IActionResult GetAccount(int accId)
        {
            _logger.LogInformation("New request for GetAccount");

            try
            {
                var response = _accountService.GetAccount(accId);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete("/account/{accId}")]
        public IActionResult DeleteAccount(int accId)
        {
            _logger.LogInformation("New request for DeleteAccount");

            try
            {
                _accountService.DeleteAccount(accId);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost("/account")]
        public IActionResult CreateAccount([FromBody] Account account)
        {
            _logger.LogInformation("New request for CreateAccount");

            try
            {
                using (var scope = new TransactionScope())
                {
                    var response = _accountService.CreateAccount(account);
                    scope.Complete();
                    return new OkObjectResult(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("/account")]
        public IActionResult UpdateAccount([FromBody] Account account)
        {
            _logger.LogInformation("New request for UpdateAccount");

            try
            {
                using (var scope = new TransactionScope())
                {
                    var response = _accountService.UpdateAccount(account);
                    scope.Complete();
                    return new OkObjectResult(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
