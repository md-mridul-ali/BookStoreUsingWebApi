using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Repos
{
    public class OrderRepo:IRepository<Order>
    {
        UMSContext db;
        public OrderRepo(UMSContext db)
        {
            this.db = db;
        }

        public bool Create(Order c)
        {
            db.Orders.Add(c);
            return db.SaveChanges() > 0;
        }
        //Show all Books
        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        //Show Book by ID
        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        //Update Book
        public bool Update(Order c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        //Delete Book by ID
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}
