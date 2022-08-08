using AutoMapper;
using BookManager.Domain.Entities;
using BookManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookModel, Book>();
        }
    }
}
