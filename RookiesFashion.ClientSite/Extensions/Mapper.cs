using AutoMapper;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Models.ViewModels;

namespace RookiesFashion.ClientSite.Extensions;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Product, ProductVM>();
        
    }
}