using NS.OBS.Data.Entities;
using NS.OBS.Model;
using NS.OBS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Business
{
    public class BookBusiness:IBookBusiness
    {
        private readonly IBookRepo _iBookRepo;
        public BookBusiness(IBookRepo iBookRepo)
        {
            _iBookRepo = iBookRepo;
        }
        public bool AddBook(BookModel detail, string wwwrootPath)
        {
          return _iBookRepo.AddBook(detail,wwwrootPath);

        }
        public List<BookModel> ShowBooks()
        {

            return _iBookRepo.ShowBooks();

        }
        public List<BookModel> UpdateBook(int id)
        {
            return _iBookRepo.UpdateBook(id);
        }

        public bool FinalUpdate(BookModel detail, int BookId, string wwwrootPath)
        {
            return _iBookRepo.FinalUpdate(detail,BookId, wwwrootPath);
        }


        public bool FinalDelete(BookModel bookModel, int BookId)
        {
           return  _iBookRepo.FinalDelete(bookModel,BookId);

        }
        public BookDetail GetBookById(int BookId)
        {
            return _iBookRepo.GetBookById(BookId);
        }
        //public List<BookDetail> GetBookByName()
        //{
        //    return _iBookRepo.GetBookByName();
        //}

    }
}
