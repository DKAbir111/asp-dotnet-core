using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_dotnet_core.Models;

using BookStore.Data.Interfaces;
using BookStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace asp_dotnet_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private BookRepository books = new BookRepository();
        //get all books => api/books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(books.GetAllBooks());
        }


        //get book by id => api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = books.GetBookById(id);
            if (book == null)
            {
                return NotFound($"Book with id {id} not found.");
            }
            return Ok(book);
        }

    }
}