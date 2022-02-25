using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Repository
{
    public interface IBookRepo
    {
       public  bool AddBook(BookModel bookModel);

        List<BookModel> ShowBooks();

        List<BookModel> UpdateBook(int id);


        public bool FinalUpdate(BookModel bookModel);

        public List<BookModel> DeleteBook(int id);
        public bool FinalDelete(BookModel bookModel);
    }
}
