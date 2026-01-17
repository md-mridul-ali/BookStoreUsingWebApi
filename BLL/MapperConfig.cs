using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category,CategoryDTO>().ReverseMap();
            cfg.CreateMap<Book,BookDTO>().ReverseMap();
        });
        
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
    }
}
