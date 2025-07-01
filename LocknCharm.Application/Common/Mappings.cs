using AutoMapper;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.DTOs.ApplicationUser;
using LocknCharm.Application.DTOs.Auth;
using LocknCharm.Application.DTOs.Cart;
using LocknCharm.Application.DTOs.CartItem;
using LocknCharm.Application.DTOs.Category;
using LocknCharm.Application.DTOs.DeliveryDetail;
using LocknCharm.Application.DTOs.Order;
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

            //CartItem Mappings
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) 
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Price * src.Quantity))
                .ReverseMap();
            CreateMap<CartItem, CreateCartItemDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Price, opt => opt.Ignore());

            //Cart Mappings
            CreateMap<Cart, CartDTO>()
                .ReverseMap();
            CreateMap<Cart, CreateCartDTO>()
                .ReverseMap();

            //DeliveryDetail Mappings
            CreateMap<DeliveryDetail, DeliveryDetailDTO>()
                .ReverseMap();
            CreateMap<DeliveryDetail, CreateDeliveryDetailDTO>()
                .ReverseMap();
            CreateMap<DeliveryDetail, UpdateDeliveryDetailDTO>()
                .ReverseMap();

            //Order Mappings
            CreateMap<Order, OrderDTO>()
                .ReverseMap();

        }
    }
}
