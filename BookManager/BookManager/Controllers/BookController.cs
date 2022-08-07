using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BookController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var books = await _repository.Book.GetAllBooksAsync(trackChanges: false);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return View(booksDto);
        }

        public async Task<IActionResult> Create()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] BookForCreationDto bookForCreationDto)
        {
            var book = _mapper.Map<Book>(bookForCreationDto);
            _repository.Book.CreateBook(book);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _repository.Book.GetBookAsync(id, trackChanges: true);
            var bookDto = _mapper.Map<BookForUpdateDto>(book);
            return View(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Price")] BookForUpdateDto bookForUpdateDto)
        {
            var bookEntity = await _repository.Book.GetBookAsync(bookForUpdateDto.Id, trackChanges: true);
            _mapper.Map(bookForUpdateDto, bookEntity);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _repository.Book.GetBookAsync(id, trackChanges: false);
            _repository.Book.DeleteBook(book);
            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
