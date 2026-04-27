using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = new List<string> { "Value1", "Value2", "Value3" };
            return Ok(values);
        }
    }
}