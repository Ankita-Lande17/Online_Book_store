using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Business
{
    public interface IBookBusiness
    {
       public bool AddBook(BookModel detail,string wwwrootPath);

        List<BookModel> ShowBooks();
        List<BookModel> UpdateBook(int id);
        bool FinalUpdate(BookModel detail,int BookId, string wwwrootPath);
        bool FinalDelete(BookModel bookModel, int BookId);
        BookDetail GetBookById(int BookId);
       //public List<BookDetail> GetBookByName();
    }
}
