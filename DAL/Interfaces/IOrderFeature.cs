using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IOrderFeature<T>
    {
        //public Order  UpdateStatus(int id, string status);
        bool UpdateStatus(int id, string status);
    }
}
