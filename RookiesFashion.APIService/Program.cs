using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Services;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extension;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using RookiesFashion.APIService.Data.Mapping;
using RookiesFashion.SharedRepo.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var validationResult = new ValidationResultModel(actionContext.ModelState);
                return new BadRequestObjectResult(new ResponseObject(){
                    Data = validationResult.Errors,
                    Message = validationResult.Message
                });
            };
        }).AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RookiesFashionContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RookiesFashion_Connection_String")).UseLazyLoadingProxies(), ServiceLifetime.Scoped);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile(provider.GetService<ICloudinaryService>(), provider.GetService<ISizeService>(), provider.GetService<IColorService>()));
    }).CreateMapper());



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        policy =>
        {
            policy.WithOrigins(builder.Configuration["AllowedHosts"])
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigins");
// app.UseAuthorization();

app.MapControllers();

app.Run();