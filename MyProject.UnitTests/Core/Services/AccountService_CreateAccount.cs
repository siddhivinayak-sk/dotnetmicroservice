using System;
using Xunit;
using Newtonsoft.Json;

namespace MyProject.UnitTests.Core.Services
{
    public class AccountService_CreateAccount : IClassFixture<BaseEfRepoTestFixture>
    {
        BaseEfRepoTestFixture _fixture;

        public AccountService_CreateAccount(BaseEfRepoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CreateAccount()
        {

            var actual = _fixture.AccountService.CreateAccount(_fixture.Account);
            Assert.Equal(JsonConvert.SerializeObject(_fixture.Account), JsonConvert.SerializeObject(actual));

        }
    }
}
