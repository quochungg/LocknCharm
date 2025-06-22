using AutoMapper;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.DTOs.ApplicationUser;
using LocknCharm.Application.DTOs.Auth;
using LocknCharm.Application.DTOs.Category;
using LocknCharm.Application.DTOs.Role;
using LocknCharm.Application.DTOs.RoleClaims;
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

            //User Mappings
            CreateMap<ApplicationUser, ApplicationUserDTO>()
                .ReverseMap();
            CreateMap<ApplicationUser, RegisterRequestDTO>()
                .ForMember(dest => dest.RoleId, opt => opt.Ignore())
                .ReverseMap();

            //Role Mappings
            CreateMap<ApplicationRole, RoleDTO>()
                .ReverseMap();
            CreateMap<ApplicationRole, CreateRoleDTO>()
                .ReverseMap();
            CreateMap<ApplicationRole, UpdateRoleDTO>()
                .ReverseMap();

            //RoleClaim Mappings
            CreateMap<ApplicationRoleClaim, RoleClaimDTO>()
                .ReverseMap();
            CreateMap<ApplicationRoleClaim, CreateRoleClaimDTO>()
                .ReverseMap();
            CreateMap<ApplicationRoleClaim, UpdateRoleClaimDTO>()
                .ReverseMap();
        }
    }
}
