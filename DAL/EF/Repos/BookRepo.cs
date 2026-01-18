using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Repos
{
    public class BookRepo: IRepository<Book>, IBookFeature
    {
        UMSContext db;
        public BookRepo(UMSContext db)
        {
            this.db = db;
        }
        //Create Book
        public bool Create(Book c)
        {
            db.Books.Add(c);
            return db.SaveChanges() > 0;
        }

        //Show all Books
        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        //Show Book by ID
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        //Update Book
        public bool Update(Book c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        //Delete Book by ID
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Books.Remove(ex);
            return db.SaveChanges() > 0;
        }

        //Functionality implemented
        //Search Book by Title
        public List<Book> GetByName(string name)
        {
            var book = (from b in db.Books
                        where b.Title.Contains(name)
                        select b).ToList();
            return book;
        }
        //aditional 
        public bool UpdateStatus(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
