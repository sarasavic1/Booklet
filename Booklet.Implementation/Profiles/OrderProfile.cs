/*using AutoMapper;
using Booklet.Application.DataTransfer;
using Booklet.DataAccess;
using Booklet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booklet.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile(BookletContext context)
        {
            CreateMap<OrderDto, Order>()
               .ForMember(o => o.OrderLines, x => x.MapFrom(dto => dto.OrderLines.Select(ol => new OrderLine
               {
                   BookName = context.Books.Find(ol.BookId).Title,
                   Quantity=ol.Quantity,
                   Price= context.Books.Find(ol.BookId).Price,
                   BookId= context.Books.Find(ol.BookId).Id
               }))); 
        }
    }
}*/
