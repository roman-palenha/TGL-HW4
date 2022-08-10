using AutoMapper;
using BookManager.Domain.Entities;
using BookManager.Domain.Models;
using BookManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly BaseService<Book> _baseService;
        private readonly IMapper _mapper;
        public BookService(BaseService<Book> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        public async Task<bool> CreateBook(BookModel bookModel)
        {
            if(bookModel != null)
            {
                var result = _mapper.Map<Book>(bookModel);
                await _baseService.Insert(result);
                return true;
            }
            return false;
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _baseService.Get(id);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _baseService.GetRange();
        }

        public async Task<bool> RemoveBook(Guid id)
        {
            var book = await _baseService.Get(id);
            if (book != null)
            {
                await _baseService.Remove(book);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateBook(Book bookForUpdate)
        {
            if(bookForUpdate != null)
            {
                await _baseService.Update(bookForUpdate);
                return true;
            }
            return false;
        }
    }
}
