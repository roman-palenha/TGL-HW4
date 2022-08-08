using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookModel>> GetAllBooksAsync(bool trackChanges);
        Task<BookModel> GetBookAsync(Guid id, bool trackChanges);
        void CreateBook(BookModel book);
        void DeleteBook(BookModel book);
    }
}
