using System;
using Xunit;
using Newtonsoft.Json;

namespace MyProject.UnitTests.Core.Services
{
    public class CustomerService_GetCustomer : IClassFixture<BaseEfRepoTestFixture>
    {
        BaseEfRepoTestFixture _fixture;

        public CustomerService_GetCustomer(BaseEfRepoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetCustomer()
        {

            var actual = _fixture.CustomerService.GetCustomer(100);
            Assert.Equal(JsonConvert.SerializeObject(_fixture.Customer), JsonConvert.SerializeObject(actual));

        }
    }
}
