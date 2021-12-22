using System;
using Xunit;
using Newtonsoft.Json;

namespace MyProject.UnitTests.Core.Services
{
    public class AccountService_UpdateAccount : IClassFixture<BaseEfRepoTestFixture>
    {
        BaseEfRepoTestFixture _fixture;

        public AccountService_UpdateAccount(BaseEfRepoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void UpdateAccount()
        {

            var actual = _fixture.AccountService.UpdateAccount(_fixture.Account);
            Assert.Equal(JsonConvert.SerializeObject(_fixture.Account), JsonConvert.SerializeObject(actual));

        }
    }
}
