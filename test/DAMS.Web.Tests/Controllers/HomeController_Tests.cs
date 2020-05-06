using System.Threading.Tasks;
using DAMS.Web.Controllers;
using Shouldly;
using Xunit;

namespace DAMS.Web.Tests.Controllers
{
    public class HomeController_Tests: DAMSWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
