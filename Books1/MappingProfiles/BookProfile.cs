using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;

namespace Books1.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDTO, Book>();
        }
    }
}
