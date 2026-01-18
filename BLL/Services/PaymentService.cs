using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PaymentService
    {
        DataFactory factory;
        public PaymentService(DataFactory factory)
        {
            this.factory = factory;
        }

        public List<PaymentDTO> Get()
        {
            //var data = factory.Get();
            var data = factory.GetPaymentRepository().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<PaymentDTO>>(data);
            return ret;
        }

        public PaymentDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<PaymentDTO>(factory.GetPaymentRepository().Get(id));
        }
        public bool Create(PaymentDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Payment>(c);
            data.PaymentDate = DateTime.Now;
            return factory.GetPaymentRepository().Create(data);
            //var paymentRepo = factory.GetPaymentRepository();
            //var orderRepo = factory.GetOrderRepository();

            //var order = orderRepo.Get(c.OId);

            //// Check order exists
            //if (order == null)
            //    return false;

            //var mapper = MapperConfig.GetMapper();
            //var data = mapper.Map<Payment>(c);
            //data.PaymentDate = DateTime.Now;

            //// Save payment
            //return factory.GetPaymentRepository().Create(data);

            //// Remove order after payment
            //return factory.GetOrderRepository().Delete(c.OId);
            ////orderRepo.Delete(c.OId);

            ////return true;
        }
    }
}
