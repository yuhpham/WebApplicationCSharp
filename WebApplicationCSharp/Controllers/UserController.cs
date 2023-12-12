using Microsoft.AspNetCore.Mvc;
using WebApplicationCSharp.dto.Reponse.User;
using WebApplicationCSharp.dto.Request.User;
using WebApplicationCSharp.Service.LogInService;
using WebApplicationCSharp.Service.UserService;

namespace WebApplicationCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILoggingService _loggingService;
        public UserController()
        {
            _service = new UserService();
            _loggingService = new LoggingService();
        }

        [Route("get-user-id")]

        [HttpGet]

        public async Task<IActionResult> GetUserId([FromQuery] Guid Id)
        {
            try
            {
                UserResponse response = await _service.GetUserId(Id);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [Route("get-user")]

        [HttpGet]

        public async Task<IActionResult> GetListUser([FromQuery] UserRequest request)
        {
            try
            {
                UserGetListResponse response = await _service.GetListUser(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [Route("add-user")]

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromQuery] UserCreateRequest request)
        {
            try
            {
                bool response = await _service.CreateUser(request);

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }

        }


        [Route("update-User")]

        [HttpPut()]
        public async Task<ActionResult> PutProduct([FromQuery] UserUpdateRequest request)
        {
            try
            {
                UserResponse response = await _service.UpdateUser(request);
                return new JsonResult(response);


            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

    }
}
