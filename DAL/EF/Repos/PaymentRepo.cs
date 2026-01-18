using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Repos
{
    public class PaymentRepo:IPaymentFeature<Payment>
    {
        UMSContext db;
        public PaymentRepo(UMSContext db)
        {
            this.db = db; 
        }

        public bool Create(Payment c)
        {
            db.Payments.Add(c);
            return db.SaveChanges() > 0;
        }
        //Show all Books
        public List<Payment> Get()
        {
            return db.Payments.ToList();
        }

        //Show Book by ID
        public Payment Get(int id)
        {
            return db.Payments.Find(id);
        }

    }
}
