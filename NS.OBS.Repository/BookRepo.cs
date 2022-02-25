using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NS.OBS.Repository
{
    public class BookRepo : IBookRepo
    {
        public bool AddBook(BookModel bookModel)
        {
            using (var context = new BookDBContext())
            {
                var paraamList = new List<SqlParameter>();
                paraamList.Add(new SqlParameter("@BookName", bookModel.BookName));
                paraamList.Add(new SqlParameter("@Category", bookModel.Category));
                paraamList.Add(new SqlParameter("@Author", bookModel.Author));
                paraamList.Add(new SqlParameter("@Publisher", bookModel.Publisher));
                paraamList.Add(new SqlParameter("@Description", bookModel.Description));
                context.Database.ExecuteSqlRaw("uspAddBook @BookName,@Category, @Author, @Publisher, @Description", paraamList);

            }
            return true;
        }

        public List<BookModel> ShowBooks()
        {
            List<BookModel> returnList = new List<BookModel>();
            using (var context = new BookDBContext())
            {
                var detail = context.CustomBookModel.FromSqlRaw("uspGetBook").ToList();

                returnList = detail;
            }
            return returnList;
        }

         //public BookDetail GetBookById(int BookId)
         //{
         //   BookDBContext context = new BookDBContext();
         //   var bookId = context.BookDetail.Where(x => x.BookId == BookId).FirstOrDefault();
         //   return bookId;
         // }
        public List<BookModel> UpdateBook(int id)
        {
           List<BookModel> returnList = new List<BookModel>();
            using (var context = new BookDBContext())
            {

                returnList=context.CustomBookModel.FromSqlRaw("uspUpdateBook {0}", id).ToList();
               
            }
            return returnList;
        }
        public bool FinalUpdate(BookModel bookModel)
        {
            using (var context = new BookDBContext())
            {
                var paraamList = new List<SqlParameter>();
                paraamList.Add(new SqlParameter("@BookId", bookModel.BookId));
                paraamList.Add(new SqlParameter("@BookName", bookModel));
                paraamList.Add(new SqlParameter("@Category", bookModel.Category));
                paraamList.Add(new SqlParameter("@Author", bookModel.Author));
                paraamList.Add(new SqlParameter("@Publisher", bookModel.Publisher));
                paraamList.Add(new SqlParameter("@Description", bookModel.Description));
                context.Database.ExecuteSqlRaw("uspFinalUpdate @BookId,@Category,@Author,@Publisher,@Description ", paraamList);

            }
            return true;
        }
        public List<BookModel> DeleteBook(int id)
        {
            List<BookModel> returnList = new List<BookModel>();
            using (var context = new BookDBContext())
            {

                returnList = context.CustomBookModel.FromSqlRaw("uspUpdateBook {0}", id).ToList();
            }
            return returnList;
        }
        public bool FinalDelete(BookModel bookModel)
        {
            using (var context = new BookDBContext())
            {
                var paraamList = new List<SqlParameter>();
                paraamList.Add(new SqlParameter("@BookId", bookModel.BookId));
                context.Database.ExecuteSqlRaw("uspDeleteBook @BookId", paraamList);

            }
            return true;
        }
    }
}

