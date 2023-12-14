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
        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> User  </returns>

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
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get List User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List User</returns>
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
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>new User if True</returns>
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
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Updated User if True</returns>
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
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
