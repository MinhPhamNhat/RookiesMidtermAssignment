using AutoMapper;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.ViewModels;

namespace RookiesFashion.ClientSite.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile(ICloudinaryService cloudinaryService)
    {
        CreateMap<Product, ProductVM>();
        CreateMap<Category, CategoryVM>();
        CreateMap<Image, ImageVM>()
        .ForMember(dest => dest.Url, act => act.MapFrom(src => cloudinaryService.BuildImageUrl($"{src.ImageName}.{src.Extension}")));
        CreateMap<Color, ColorVM>();
        CreateMap<Size, SizeVM>();
    }
}