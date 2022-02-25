using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS.OBS.Business
{
    public interface IBookBusiness
    {
        bool AddBook(BookModel bookModel);

        List<BookModel> ShowBooks();
        List<BookModel> UpdateBook(int id);
        bool FinalUpdate(BookModel bookModel);
        List<BookModel> DeleteBook(int id);
        bool FinalDelete(BookModel bookModel);
    }
}
