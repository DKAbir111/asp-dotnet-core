using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data.Models;

namespace BookStore.Data.Interfaces
{
    public interface IBookRepository
    {
        int Count { get; }

        List<Books> GetAllBooks();
        Books? GetBookById(Guid id);
    }
}