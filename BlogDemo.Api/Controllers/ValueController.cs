using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BlogDemo.Api.Controllers
{
    [Route("api/values")]
    public class ValueController : Controller
    {
        public IActionResult Get()
        {
            return Ok("hello");
        }
    }
}
