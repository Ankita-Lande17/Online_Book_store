using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NS.OBS.Business;
using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.IO;

namespace NS.OBS.WEB.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookBusiness _IBookBusiness=null;

		private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookBusiness iBookBusiness,IWebHostEnvironment webHostEnvironment)
        {
            _IBookBusiness = iBookBusiness;
			_webHostEnvironment = webHostEnvironment;
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
        public IActionResult Create(BookModel detail)
        {
            if (ModelState.IsValid)
            {
              //  BookModel bookModel = new BookModel();
				string folder = "~/books/bookpic";
				folder += Guid.NewGuid().ToString() + "-" + detail.BookPhoto.FileName;
				detail.ImgUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);  

               detail.BookPhoto.CopyTo(new FileStream(serverFolder, FileMode.Create));
                
                _IBookBusiness.AddBook(detail);
                return RedirectToAction("ShowBooks");
            }
            return View();
        }
        public IActionResult ShowBooks()
        {
            return View(_IBookBusiness.ShowBooks());
        }
        public IActionResult Update(int BookId)
        {
            return View(_IBookBusiness.GetBookById(BookId));
        }

        [HttpPost]
        public IActionResult Update(BookDetail detail, int BookId )
        {
            Console.WriteLine(detail.BookId);
            detail.BookId = Convert.ToInt32(detail.BookId);
            _IBookBusiness.FinalUpdate(detail,BookId);
            return RedirectToAction("ShowBooks");
        }
        public IActionResult Delete(int BookId)
        {
            return View(_IBookBusiness.GetBookById(BookId));
        }

        [HttpPost]
        public IActionResult Delete(BookModel bookModel, int BookId)
        {
            Console.WriteLine(bookModel.BookId);
            _IBookBusiness.FinalDelete(bookModel,BookId);
            return RedirectToAction("ShowBooks");
        }
        public IActionResult GetBookById(int BookId)
        {
            return View(_IBookBusiness.GetBookById(BookId));
        }
    }
}

