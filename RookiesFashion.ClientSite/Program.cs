using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RookiesFashion.APIService.Services;
using RookiesFashion.ClientSite.Profiles;
using RookiesFashion.ClientSite.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductService, ProductService>(); 
builder.Services.AddScoped<RookiesFashion.APIService.Services.Interfaces.ICloudinaryService, RookiesFashion.APIService.Services.CloudinaryService>(); 
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile(provider.GetService<RookiesFashion.APIService.Services.Interfaces.ICloudinaryService>()));
    }).CreateMapper());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
