using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Interfaces;
using BookStore.Data.Models;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
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

        public int Count => books.Count;

        public List<Books> GetAllBooks()
        {
            return books;
        }

        public Books? GetBookById(Guid id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }
    }
}