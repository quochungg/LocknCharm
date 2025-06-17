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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
            CreateMap<CreatePreMadeKeychainDTO, PreMadeKeychain>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<UpdatePreMadeKeychainDTO, PreMadeKeychain>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ReverseMap();

            //Category Mappings
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
            CreateMap<Category, CreateCategoryDTO>()
                .ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>()
                .ReverseMap();
        }
    }
}
