using DAL.EF;
using DAL.EF.Models;
using DAL.EF.Repos;
using DAL.Interfaces;

namespace DAL
{
    public class DataFactory
    {
        UMSContext db;
        public DataFactory(UMSContext db)
        {
            this.db = db;
        }
        public IRepository<Book> GetBookRepository()
        {
            return new BookRepo(db);
        }
        public IRepository<Category> GetCategoryRepository()
        {
            return new CategoryRepo(db);
        }
        public IBookFeature BookFeature()
        {
            return new BookRepo(db);
        }
        public IRepository<Order> GetOrderRepository()
        {
            return new OrderRepo(db);
        }
        public IPaymentFeature<Payment> GetPaymentRepository()
        {
            return new PaymentRepo(db);
        }
    }
}
