using App_Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Application.Errors;

namespace E_Commerce_Application.Controllers
{
    public class BuggyController:CBaseController
    {
        private readonly StoreDbContext _dbContext;
        public BuggyController(StoreDbContext cxt)
        { 
            _dbContext = cxt;
        }

        [HttpGet]
        [Route("/not found")]
        public ActionResult GetNotFound()
        {
            return NotFound(new APIResponse(404));
        }

       /* [HttpGet]
        [Route("/server error")]
        public ActionResult GetServerError()
        {

        }*/

        [HttpGet]
        [Route("/bad request")]
        public ActionResult BadRequest()
        {
            return BadRequest(new APIResponse(400));
        }
       /* [HttpGet]
        [Route("/not found")]
        public ActionResult GetNotFound()
        {

        }*/

    }
}
