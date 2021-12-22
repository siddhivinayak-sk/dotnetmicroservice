using System;
using Xunit;
using Newtonsoft.Json;

namespace MyProject.UnitTests.Core.Services
{
    public class CustomerService_CreateCustomer : IClassFixture<BaseEfRepoTestFixture>
    {
        BaseEfRepoTestFixture _fixture;

        public CustomerService_CreateCustomer(BaseEfRepoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CreateCustomer()
        {

            var actual = _fixture.CustomerService.CreateCustomer(_fixture.Customer);
            Assert.Equal(JsonConvert.SerializeObject(_fixture.Customer), JsonConvert.SerializeObject(actual));

        }
    }
}
