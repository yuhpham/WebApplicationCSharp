using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using WebApplicationCSharp.Service.Interface;
using WebApplicationCSharp.Service;
using WebApplicationCSharp.dto.Request.AppVesion;
using WebApplicationCSharp.dto.Reponse.Appversion;



namespace WebApplicationCSharp.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private IApplicationService _ApplicationService;

        public ApplicationController()
        {

            _ApplicationService = new ApplicationService();


        }
        [Route("get-version")]
        [HttpGet()]

        public async Task<IActionResult> Get([FromQuery] AppVersionGetListRequest request)
        { try
            {
                 AppVersionGetListResponse reponse = await _ApplicationService.GetAppVersionGetList(request);
                
                return new JsonResult(reponse);


            }
            catch (Exception ex) 
            { 
                
                Console.WriteLine(ex.Message);

              return StatusCode(500, ex.Message);
                
            }

        }





    }

}
