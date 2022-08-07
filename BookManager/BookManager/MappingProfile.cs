using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace BookManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<BookForUpdateDto, Book>().ReverseMap();
        }
    }
}
