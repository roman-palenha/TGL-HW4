using AutoMapper;
using BookManager.Domain.Entities;
using BookManager.Domain.Models;
using BookManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetBooks();

            return View(result);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookModel book)
        {
            var result = await _bookService.CreateBook(book);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _bookService.GetBook(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book bookForUpdate)
        {
            await _bookService.UpdateBook(bookForUpdate);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookService.RemoveBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
    
}
