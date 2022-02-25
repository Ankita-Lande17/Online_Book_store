using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Repository
{
    public interface IBookRepo
    {
       public  bool AddBook(BookDetail detail);

        List<BookModel> ShowBooks();

        List<BookModel> UpdateBook(int id);


        public bool FinalUpdate(BookDetail detail);

        public List<BookModel> DeleteBook(int id);
        public bool FinalDelete(BookModel bookModel);
    }
}
