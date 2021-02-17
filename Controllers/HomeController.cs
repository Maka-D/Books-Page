using Microsoft.AspNetCore.Mvc;
using Project_2_2.AppServices.AuthorsDetailsAppService;
using Project_2_2.AppServices.AuthorsDetailsAppService.DTOs;
using Project_2_2.AppServices.BooksDetailsAppService;
using Project_2_2.AppServices.BooksDetailsAppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.Controllers
{
    public class HomeController :Controller
    {
        private readonly IBooksDetails _booksDetails;
        private readonly IAuthorsDetails _authorsDetails;
        public HomeController(IBooksDetails booksDetails, IAuthorsDetails authorsDetails)
        {
            _booksDetails = booksDetails;
            _authorsDetails = authorsDetails;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(string BookName, DateTime WrittenDate)
        {
            string result = _booksDetails.AddBooks(BookName, WrittenDate);
            return Json(result);
        }
        [HttpPost]
        public IActionResult ShowBooks()
        {
            List<BooksDetailsInput> BooksList = _booksDetails.PrintBooks();
            return View(BooksList);
        }
        [HttpPost]
        public IActionResult AddAuthor(int bookId)
        {
            BooksDetailsInput book = _booksDetails.GetBookInfo(bookId);
            return View(book);
        }
        [HttpPost]
        public IActionResult CreateAuthor(AuthorsDetailsInput authorInfo)
        {
            _authorsDetails.CreateAuthor(authorInfo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(int BookId)
        {
            FullInfoOutput result = _booksDetails.GetFullInfoToEdit(BookId);
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(FullInfoOutput updatedInfo)
        {
            _authorsDetails.UpdateBookAndAuthorInfo(updatedInfo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int BookId)
        {
            _authorsDetails.DeleteBookAndAuthor(BookId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ShowBooksWithAuthorDetails()
        {
            List<FullInfoOutput> result = _booksDetails.BooksWithAuthor();
            return View(result);
        }
    }
}
