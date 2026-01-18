using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IBookFeature
    {
        public List<Book> GetByName(string name);
    }
}
