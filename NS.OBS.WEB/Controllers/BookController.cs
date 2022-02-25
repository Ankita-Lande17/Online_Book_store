using Microsoft.AspNetCore.Mvc;
using NS.OBS.Business;
using NS.OBS.Model;
using System;

namespace NS.OBS.WEB.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookBusiness _IBookBusiness;
        public BookController(IBookBusiness iBookBusiness)
        {
            _IBookBusiness = iBookBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                _IBookBusiness.AddBook(bookModel);
                return RedirectToAction("ShowBooks");
            }
            return View();
        }
        public IActionResult ShowBooks()
        {
            return View(_IBookBusiness.ShowBooks());
        }
        public IActionResult EditBook(int id)
        {
            return View(_IBookBusiness.UpdateBook(id));
        }

        [HttpPost]
        public IActionResult Edit(BookModel bookModel)
        {
            Console.WriteLine(bookModel.BookId);
            bookModel.BookId = Convert.ToInt32(bookModel.BookId);
            _IBookBusiness.FinalUpdate(bookModel);
            return RedirectToAction("ShowBooks");
        }
        public IActionResult Delete(int id)
        {
            return View(_IBookBusiness.DeleteBook(id));
        }

        [HttpPost]
        public IActionResult Delete(BookModel bookModel)
        {
            Console.WriteLine(bookModel.BookId);
            _IBookBusiness.FinalDelete(bookModel);
            return RedirectToAction("ShowBooks");
        }
    }
}

