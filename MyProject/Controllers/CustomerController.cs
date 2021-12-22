using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MyProject.Core.Interfaces.Services;

using MyProject.Core.Models;
using Microsoft.Extensions.Logging;
using System;

namespace MyProject.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("/customer/{cusId}")]
        public IActionResult GetCustomer(int cusId)
        {
            _logger.LogInformation("New request for GetCustomer");

            try
            {
                var response = _customerService.GetCustomer(cusId);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost("/customer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            _logger.LogInformation("New request for CreateCustomer");

            try
            {
                using (var scope = new TransactionScope())
                {
                    var response = _customerService.CreateCustomer(customer);
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
