using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : RepositoryBase<BookModel>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public void CreateBook(BookModel book)
        {
            Create(book);
        }

        public void DeleteBook(BookModel book)
        {
            Delete(book);
        }

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public async Task<BookModel> GetBookAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(b => b.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        }
    }
}
