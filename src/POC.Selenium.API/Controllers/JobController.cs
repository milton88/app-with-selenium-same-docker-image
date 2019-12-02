using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace POC.Selenium.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return Job.Job.Execute();
        }
    }
}