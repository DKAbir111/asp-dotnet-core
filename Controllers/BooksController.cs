using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_dotnet_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace asp_dotnet_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        public List<Books> books = new List<Books>
        {
            new Books
            {
                Id=Guid.NewGuid(),
                Title="The Great Gatsby",
                Author="F. Scott Fitzgerald",
                Category="Classic",
                PublicationYear=new DateTime(1925,4,10)
            },
            new Books
            {
                Id=Guid.NewGuid(),
                Title="To Kill a Mockingbird",
                Author="Harper Lee",
                Category="Classic",
                PublicationYear=new DateTime(1960,7,11)
            },
            new Books
            {
                Id=Guid.NewGuid(),
                Title="1984",
                Author="George Orwell",
                Category="Dystopian",
                PublicationYear=new DateTime(1949,6,8)
            }
        };



        //get all books => api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            if (books == null || books.Count == 0)
            {
                return NotFound("No books found.");
            }
            return Ok(books);
        }


        //get book by id => api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Book with id {id} not found.");
            }
            return Ok(book);
        }


    }
}