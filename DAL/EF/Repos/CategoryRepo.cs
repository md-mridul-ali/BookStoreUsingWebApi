using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.EF.Repos
{
    public class CategoryRepo: IRepository<Category>
    {
        UMSContext db;
        public CategoryRepo(UMSContext db)
        {
            this.db = db;
        } 
        //Create Category
        public bool Create(Category c)
        {
            db.Categories.Add(c);
            return db.SaveChanges()>0;
        }

        //Show all categories
        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        //Show Category by ID
        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        //Update Category
        public bool Update(Category c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        //Delete Category by ID
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool UpdateStatus(int id, string status)
        {
            throw new NotImplementedException();
        }

        //additional
        //public UpdateStatus(int id, string status)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
