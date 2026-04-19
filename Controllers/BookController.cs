using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public static List<Book> Books = new List<Book>{
        new Book { Id = 1, Title = "C# Basics", Author = "John Doe" },
        new Book { Id = 2, Title = "ASP.NET Core Guide", Author = "Jane Smith" },
        new Book { Id = 3, Title = "Web API Development", Author = "Michael Lee" },
        new Book { Id = 4, Title = "Clean Code", Author = "Robert Martin" },
        new Book { Id = 5, Title = "Design Patterns", Author = "Erich Gamma" }
        };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
