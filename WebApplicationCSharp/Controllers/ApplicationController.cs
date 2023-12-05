using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplicationCSharp.dto.Reponse.Appversion;
using WebApplicationCSharp.dto.Request.AppVesion;
using WebApplicationCSharp.Service.ApplicationService;
using WebApplicationCSharp.Service.LogInService;



namespace WebApplicationCSharp.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly ILoggingService _loggingService;


        public ApplicationController()
        {

            _applicationService = new ApplicationService();

            _loggingService = new LoggingService();
        }


        [Route("get-version")]
        [HttpGet()]

        public async Task<IActionResult> Get([FromQuery] AppVersionGetListRequest request)
        {
            try
            {

                AppVersionGetListResponse reponse = await _applicationService.GetAppVersionList(request);

                return new JsonResult(reponse);

            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);


                return StatusCode(500, ex.Message);

            }
        }
        [Route("get-version-admin")]
        [HttpGet()]
        [MyAppAuthentication("Admin")]
        public async Task<IActionResult> GetVersionAdmin([FromQuery] AppVersionGetListRequest request)
        {
            try
            {
                AppVersionGetListResponse response = await _applicationService.GetAppVersionList(request);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
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
