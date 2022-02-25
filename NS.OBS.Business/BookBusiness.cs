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
        public bool AddBook(BookModel bookModel)
        {
          return _iBookRepo.AddBook(bookModel);

        }
        public List<BookModel> ShowBooks()
        {

            return _iBookRepo.ShowBooks();

        }
        public List<BookModel> UpdateBook(int id)
        {
            return _iBookRepo.UpdateBook(id);
        }

        public bool FinalUpdate(BookModel bookModel)
        {
            return _iBookRepo.FinalUpdate(bookModel);
        }

        public List<BookModel> DeleteBook(int id)
        {
            return _iBookRepo.DeleteBook(id);
        }

        public bool FinalDelete(BookModel bookModel) => _iBookRepo.FinalDelete(bookModel);
    }
}
