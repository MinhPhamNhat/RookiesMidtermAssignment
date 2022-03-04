using AutoMapper;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.APIService.Data.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile(ICloudinaryService cloudinaryService, ISizeService sizeService, IColorService colorService)
    {
        CreateMap<ProductFormDTO, Product>()
        .ForMember( dest => dest.Thumbnail ,
                        act => act.MapFrom(
                            src => cloudinaryService.FormFilesUpload(src.Files).Result))
        .ForMember( dest => dest.Sizes,
                        act => act.MapFrom(
                            src => sizeService.GetSizesFromRange(src.SizeIds)))
        .ForMember( dest => dest.Colors,
                        act => act.MapFrom(
                            src => colorService.GetColorsFromRange(src.ColorIds)));
        
    }
}