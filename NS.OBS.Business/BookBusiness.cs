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
        public bool AddBook(BookModel detail)
        {
          return _iBookRepo.AddBook(detail);

        }
        public List<BookModel> ShowBooks()
        {

            return _iBookRepo.ShowBooks();

        }
        public List<BookModel> UpdateBook(int id)
        {
            return _iBookRepo.UpdateBook(id);
        }

        public bool FinalUpdate(BookDetail detail, int BookId)
        {
            return _iBookRepo.FinalUpdate(detail,BookId);
        }


        public bool FinalDelete(BookModel bookModel, int BookId)
        {
           return  _iBookRepo.FinalDelete(bookModel,BookId);

        }
        public BookDetail GetBookById(int BookId)
        {
            return _iBookRepo.GetBookById(BookId);
        }
    }
}
