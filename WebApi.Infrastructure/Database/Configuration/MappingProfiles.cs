using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.DTOs;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Database.Configuration
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<CategoryDTO, Category>();
            //CreateMap<Category, CategoryDTO>();
            CreateMap<ItemDTO, Item>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CondominiumDTO, Condominium>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserCondominiumDTO, UserCondominium>().ReverseMap();
            CreateMap<ItemImageDTO, ItemImage>();
                //.ForMember(dest => dest.FileImagem, opt => opt.Ignore());
        }
    }
}
