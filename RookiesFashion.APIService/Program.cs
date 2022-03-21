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
using RookiesFashion.APIService.Models;
using Microsoft.AspNetCore.Identity;
using RookiesFashion.APIService.Configuration;
using RookiesFashion.APIService.Data;
using RookiesFashion.SharedRepo.Constants;
using Microsoft.AspNetCore.Authorization;
using RookiesFashion.APIService.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var validationResult = new ValidationResultModel(actionContext.ModelState);
        return new BadRequestObjectResult(new ResponseObject()
        {
            Data = validationResult.Errors,
            Message = validationResult.Message
        });
    };
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
builder.Services.AddAuthentication()
.AddLocalApi("Bearer", options =>
{
    options.ExpectedScope = "rookiesfashion.api";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(SecurityConstants.BEARER_POLICY, policy =>
    {
        policy.AddAuthenticationSchemes("Bearer");
        policy.RequireAuthenticatedUser();
    });
});
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<RookiesFashionContext>()
.AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Auth/Login";
            });

builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            });
builder.Services.AddIdentityServer()
                // .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<User>()
                .AddDeveloperSigningCredential();

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

builder.Services.AddRazorPages();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowOrigins");
app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        IdentityDataInitializer.SeedRoles(roleManager);
        IdentityDataInitializer.SeedUsers(userManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

app.Run();