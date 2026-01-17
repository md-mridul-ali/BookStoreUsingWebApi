using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);
        List<T> Get();
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(int id);

    }
}
