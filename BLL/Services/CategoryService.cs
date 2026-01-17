using BLL.DTOs;
using DAL;
using DAL.EF.Models;
//using DAL.EF.factorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CategoryService
    {
        //Categoryfactory factory;

        //public CategoryService(Categoryfactory factory)
        //{
        //    this.factory = factory;
        //}

        DataFactory factory;
        public CategoryService(DataFactory factory)
        {
            this.factory = factory;
        }
        public List<CategoryDTO> Get()
        {
            var data = factory.GetCategoryRepository().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<CategoryDTO>>(data);
            return ret;
        }

        public CategoryDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO>(factory.GetCategoryRepository().Get(id));
        }
        
        public bool Create(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return factory.GetCategoryRepository().Create(data);
        }
        public bool Update(int id,CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            data.Id = id;
            return factory.GetCategoryRepository().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.GetCategoryRepository().Delete(id);
        }

    }
}
