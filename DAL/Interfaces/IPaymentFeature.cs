using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPaymentFeature<T>
    {
        T Get(int id);
        List<T> Get();
        bool Create(T entity);
    }
}
