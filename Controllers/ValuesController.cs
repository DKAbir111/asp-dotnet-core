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

        //get all values => api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = new List<string> { "Value1", "Value2", "Value3" };
            return Ok(values);
        }

        //get value by id => api/values/{id}
        [HttpGet("{id}")]
        public IActionResult GetValueById(int id)
        {
            return Ok($"Value with id {id}");
        }
    }
}