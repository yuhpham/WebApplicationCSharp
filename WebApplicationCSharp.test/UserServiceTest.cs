using WebApplicationCSharp.dto.Reponse.User;
using WebApplicationCSharp.dto.Request.User;
using WebApplicationCSharp.Service.UserService;

namespace WebApplicationCSharp.test
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        public UserServiceTest()
        {
            _userService = new UserService();
        }
        
        [TestMethod]
        public async Task GetListUser()
        {
            // Input
            UserRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,
            };
            // Output
            UserGetListResponse response = await _userService.GetListUser(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.userGetListResponse.Count > 0); // response data > 0
        }



    } 

}
