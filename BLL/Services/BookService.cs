using BLL.DTOs;
using DAL;
using DAL.EF.Models;
//using DAL.EF.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BookService
    {
        //Bookfactory factory;
        //public BookService(Bookfactory factory)
        //{
        //    this.factory = factory;
        //}

        DataFactory factory;
        public BookService(DataFactory factory)
        {
            this.factory = factory;
        }
        public List<BookDTO> Get()
        {
            //var data = factory.Get();
            var data = factory.GetBookRepository().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<BookDTO>>(data);
            return ret;
        }

        public BookDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<BookDTO>(factory.GetBookRepository().Get(id));
        }

        public bool Create(BookDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Book>(c);
            return factory.GetBookRepository().Create(data);
        }
        public bool Update(int id,BookDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Book>(c);
            data.Id = id;
            return factory.GetBookRepository().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.GetBookRepository().Delete(id);
        }
    }
}
