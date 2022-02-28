using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NS.OBS.Data.Entities;
using NS.OBS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace NS.OBS.Repository
{
    public class BookRepo : IBookRepo
    {

        //updated - Ankita
        public bool AddBook(BookModel detail,string wwwrootPath)
        {
            string imageFileName = Path.GetFileNameWithoutExtension(detail.ImgUrl.FileName);

            string imageName = imageFileName + Path.GetExtension(detail.ImgUrl.FileName);
            string imagePath = Path.Combine(wwwrootPath + "/wwwroot/image", imageName);
            string imagePath1 = Path.Combine("/image/", imageName);

            detail.ImgUrl.CopyTo(new FileStream(imagePath, FileMode.Create));
            // DB
            using (var context = new BookDBContext())
            {
                var paraamList = new List<SqlParameter>();
                paraamList.Add(new SqlParameter("@BookName", detail.BookName));
                paraamList.Add(new SqlParameter("@Category", detail.Category));
                paraamList.Add(new SqlParameter("@ImgUrl", imagePath1));
                paraamList.Add(new SqlParameter("@Author", detail.Author));
                paraamList.Add(new SqlParameter("@Publisher", detail.Publisher));
                paraamList.Add(new SqlParameter("@Description", detail.Description));
				context.Database.ExecuteSqlRaw("uspAddBook @BookName,@Category,@ImgUrl, @Author, @Publisher, @Description", paraamList);

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

        //Update - Ankita
        public bool FinalUpdate(BookModel detail, int BookId,string wwwrootPath)
        {
            string imageFileName = Path.GetFileNameWithoutExtension(detail.ImgUrl.FileName);

            string imageName = imageFileName + Path.GetExtension(detail.ImgUrl.FileName);
            string imagePath = Path.Combine(wwwrootPath + "/wwwroot/image", imageName);
            string imagePath1 = Path.Combine("/image/", imageName);

            detail.ImgUrl.CopyTo(new FileStream(imagePath, FileMode.Create));
            using (var context = new BookDBContext())
            {
                var paraamList = new List<SqlParameter>();
                paraamList.Add(new SqlParameter("@BookId", detail.BookId));
                paraamList.Add(new SqlParameter("@BookName", detail.BookName));
                paraamList.Add(new SqlParameter("@Category", detail.Category));
                paraamList.Add(new SqlParameter("@ImgUrl", imagePath1));
                paraamList.Add(new SqlParameter("@Author", detail.Author));
                paraamList.Add(new SqlParameter("@Publisher", detail.Publisher));
                paraamList.Add(new SqlParameter("@Description", detail.Description));
                context.Database.ExecuteSqlRaw("uspFinalUpdate @BookId,@BookName,@Category,@ImgUrl,@Author,@Publisher,@Description ", paraamList);

            }
            return true;
        }
       
        public bool FinalDelete(BookModel bookModel,int BookId)
        {
            using (var context = new BookDBContext())
            {
                var paraamList = new List<SqlParameter>();
                paraamList.Add(new SqlParameter("@BookId", bookModel.BookId));
                context.Database.ExecuteSqlRaw("uspDeleteBook @BookId", paraamList);

            }
            return true;
        }
        public BookDetail GetBookById(int BookId)
        {
            using (var context = new BookDBContext())
            {
                var bookId = context.BookDetail.SingleOrDefault(x => x.BookId == BookId);
                return bookId;
            }
        }
        //public List<BookDetail> GetBookByName()
        //{
        //    using (var context = new BookDBContext())
        //    {
        //        var res = context.BookDetail.Where(x => x.BookName.StartsWith(bookName) || bookName == null).ToList();
        //        return res;
        //    }
        //}
    }
}

