/*using AutoMapper;
using Booklet.Application.DataTransfer;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>()
                 .ForMember(b => b.BookGenres, x => x.MapFrom(dto => dto.Genres.Select(bg => new BookGenre 
                 {                     
                  GenreId= bg.Id
                  
                 })));
        }
    }
}*/
