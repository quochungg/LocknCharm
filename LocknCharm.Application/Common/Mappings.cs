using AutoMapper;
using LocknCharm.Application.DTOs;
using LocknCharm.Domain.Entities;

namespace LocknCharm.Application.Common
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //PreMade Keychain Mappings
            CreateMap<PreMadeKeychain, PreMadeKeychainDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            //Category Mappings
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
        }
    }
}
