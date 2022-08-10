using BookManager.Domain.Entities;
using BookManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBook(Guid id);

        Task<bool> CreateBook(BookModel bookModel);

        Task<bool> UpdateBook(Book cardForUpdate);

        Task<bool> RemoveBook(Guid id);
    }
}
