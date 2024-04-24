using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Application.Errors;

namespace E_Commerce_Application.Controllers
{
    [Route("error/{code}")]
    public class ErrorController : CBaseController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new APIResponse(code));
        }
    }
}
