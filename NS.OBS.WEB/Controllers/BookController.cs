using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NS.OBS.Business;
using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.IO;

namespace NS.OBS.WEB.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookBusiness _IBookBusiness;
        private readonly IWebHostEnvironment _hostEnvironment;
        public BookController(ILogger<HomeController> logger,IBookBusiness IBookBusiness,IWebHostEnvironment webHostEnvironment)
        {
           
            _logger = logger;
            _IBookBusiness = IBookBusiness;
            this._hostEnvironment = webHostEnvironment;
            //         _IBookBusiness = iBookBusiness;
            //_webHostEnvironment = webHostEnvironment;
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
             var CurrentDirectory = Directory.GetCurrentDirectory();
            _IBookBusiness.AddBook(detail, CurrentDirectory);
            return RedirectToAction("ShowBooks");
            
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
        public IActionResult Update(BookModel detail, int BookId )
        {
            //return detail.BookName;
            //string imageFileName = Path.GetFileNameWithoutExtension(detail.ImgUrl.FileName);
            var CurrentDirectory = Directory.GetCurrentDirectory();
            _IBookBusiness.FinalUpdate(detail,BookId, CurrentDirectory);
           //return (imageFileName);
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
        //public IActionResult Option(string sort, string searchBook)
        //{
        //    if (searchBook != null)
        //    {
        //        var resSearch = _IBookBusiness.ShowBooks();
        //        var resSearching = resSearch.Where(stu => stu.Name.ToUpper().Contains(searchData.ToUpper()));
        //        if (sort == "Id")
        //        {

        //            var resSorting = resSearching.OrderBy(s => s.Id);
        //            return View(resSorting.ToList());
        //        }
        //        if (sort == "Name")
        //        {

        //            var resSorting = resSearching.OrderBy(s => s.Name);
        //            Console.WriteLine(resSorting.ToList()[0].Name);
        //            return View(resSorting.ToList());
        //        }
        //        return View(resSearching.ToList());
        //    }


        //    if (sort == "Id")
        //    {
        //        var resSort = _IBookBuisness.ShowBooks();
        //        var resSorting = resSort.OrderBy(s => s.Id);
        //        return View(resSorting.ToList());
        //    }
        //    if (sort == "Name")
        //    {
        //        var resSort = _IBookBuisness.ShowBooks();
        //        var resSorting = resSort.OrderBy(s => s.Name);
        //        Console.WriteLine(resSorting.ToList()[0].Name);
        //        return View(resSorting.ToList());
        //    }
        //    var res = _IBookBuisness.ShowBooks();
        //    return View(res);
        //}
        public IActionResult Details(int BookId)
        {
            return View(_IBookBusiness.GetBookById(BookId));
        }
    }
}

