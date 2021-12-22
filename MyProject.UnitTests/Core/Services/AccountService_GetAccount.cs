using System;
using Xunit;
using Newtonsoft.Json;

namespace MyProject.UnitTests.Core.Services
{
    public class AccountService_GetAccount : IClassFixture<BaseEfRepoTestFixture>
    {
        BaseEfRepoTestFixture _fixture;

        public AccountService_GetAccount(BaseEfRepoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetAccount()
        {

            var actual = _fixture.AccountService.GetAccount(100);
            Assert.Equal(JsonConvert.SerializeObject(_fixture.Account), JsonConvert.SerializeObject(actual));

        }
    }
}
