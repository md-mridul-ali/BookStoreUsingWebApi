using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderService
    {
        DataFactory factory;
        public OrderService(DataFactory factory)
        {
            this.factory = factory;
        }
        public List<OrderDTO> Get()
        {
            //var data = factory.Get();
            var data = factory.GetOrderRepository().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<OrderDTO>>(data);
            return ret;
        }

        public OrderDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<OrderDTO>(factory.GetOrderRepository().Get(id));
        }

        public bool Create(OrderDTO c)
        {
            //var mapper = MapperConfig.GetMapper();
            //var data = mapper.Map<Order>(c);
            //data.OrderDate = DateTime.Now;
            //return factory.GetOrderRepository().Create(data);
            var bookRepo = factory.GetBookRepository();
            var orderRepo = factory.GetOrderRepository();
            var book = bookRepo.Get(c.BId);

            // Check book exists
            if (book == null) return false;

            // Check stock available
            if (book.quantity < c.quantity) return false;

            // Reduce stock
            book.quantity -= c.quantity;

            // Create order
            var mapper = MapperConfig.GetMapper();
            var order = mapper.Map<Order>(c);
            order.OrderDate = DateTime.Now;

            // Save both changes
            orderRepo.Create(order);
            bookRepo.Update(book);

            return true;
        }
        public bool Update(int id, OrderDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Order>(c);
            data.Id = id;
            return factory.GetOrderRepository().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.GetOrderRepository().Delete(id);
        }
    }
}
