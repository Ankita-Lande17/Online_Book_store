using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Repository
{
    public interface IBookRepo
    {
       public  bool AddBook(BookModel detail);

        List<BookModel> ShowBooks();

        List<BookModel> UpdateBook(int id);


        public bool FinalUpdate(BookDetail detail,int BookId);

         bool FinalDelete(BookModel bookModel, int BookId);
        BookDetail GetBookById(int BookId);
    }
}
