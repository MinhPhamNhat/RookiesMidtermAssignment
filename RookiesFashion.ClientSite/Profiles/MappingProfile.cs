using AutoMapper;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.ClientSite.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile(ICloudinaryService cloudinaryService)
    {
        CreateMap<Product, ProductVM>();
        CreateMap<ProductDetail, ProductDetailVM>();
        CreateMap<Category, CategoryVM>();
        CreateMap<Image, ImageVM>()
        .ForMember(dest => dest.Url, act => act.MapFrom(src => cloudinaryService.BuildImageUrl($"{src.ImageName}.{src.Extension}")));
        CreateMap<Color, ColorVM>();
        CreateMap<Size, SizeVM>();
        CreateMap<User, UserVM>();
        CreateMap<Rating, RatingVM>();
        CreateMap<Account, AccountVM>();
        CreateMap<PagedModelDto<Product>, PagedResponseVM<ProductVM>>();
        CreateMap<PagedModelDto<Rating>, PagedResponseVM<Rating>>();
    }
}