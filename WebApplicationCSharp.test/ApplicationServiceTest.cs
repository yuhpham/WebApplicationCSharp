using WebApplicationCSharp.dto.Reponse.Appversion;
using WebApplicationCSharp.dto.Request.AppVesion;
using WebApplicationCSharp.Service.ApplicationService;

namespace WebApplicationCSharp.test
{
    [TestClass]
    public class ApplicationServiceTest
    {
        private readonly IApplicationService _ApplicationService;

        public ApplicationServiceTest()
        {
            _ApplicationService = new ApplicationService();
        }

        /// <summary>
        /// GetApplicationVersionList happy case request
        /// </summary>
        [TestMethod]
        public async Task GetApplicationVersionListTestAsync()
        {
            // Input
            AppVersionGetListRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,

            };
            // Output
            AppVersionGetListResponse response = await _ApplicationService.GetAppVersionList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count > 0); // response data > 0
        }

        /// <summary>
        /// GetApplicationVersionListWithVersion exception case request
        /// </summary>
        [TestMethod]
        public async Task GetApplicationVersionListWithVersionTestAsync()
        {
            // Input
            AppVersionGetListRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,

            };
            // Output
            AppVersionGetListResponse response = await _ApplicationService.GetAppVersionList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.Data.Count == 1); // response data > 0
        }
    }
}