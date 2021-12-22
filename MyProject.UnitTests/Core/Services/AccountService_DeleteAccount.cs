using System;
using Xunit;
using Newtonsoft.Json;

namespace MyProject.UnitTests.Core.Services
{
    public class AccountService_DeleteAccount : IClassFixture<BaseEfRepoTestFixture>
    {
        BaseEfRepoTestFixture _fixture;

        public AccountService_DeleteAccount(BaseEfRepoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void DeleteAccount()
        {

            var actual = _fixture.AccountService.DeleteAccount(100);
            Assert.Equal(JsonConvert.SerializeObject(_fixture.Account), JsonConvert.SerializeObject(actual));

        }
    }
}
