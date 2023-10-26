using AutoMapper;
using Back.Application.DTOs;
using Back.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.Mapper
{
    public class OrderingMappingProfile : Profile
    {
        public OrderingMappingProfile()
        {
            
            CreateMap<Producto, ProductoResponse>().ReverseMap();
           
            //Agregar producto
            CreateMap<Producto, ProductoDto>().ReverseMap();          
            //Editar producto
            CreateMap<Producto, EditProductoDto>().ReverseMap();
            
          
        }
    }
}
