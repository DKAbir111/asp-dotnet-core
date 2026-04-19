using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"value{id}");
        }
    }
}
