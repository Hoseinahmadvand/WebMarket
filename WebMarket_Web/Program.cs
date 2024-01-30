using Microsoft.EntityFrameworkCore;
using WebMarket_CoreLayer.DTOs.MainPage;
using WebMarket_CoreLayer.Servises.Brands;
using WebMarket_CoreLayer.Servises.Categories;
using WebMarket_CoreLayer.Servises.Product;
using WebMarket_DataLayer.Context;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Connection To DB
builder.Services.AddDbContext<WebMarketContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//IOC
builder.Services.AddScoped<ICateoryService,CateoryService>();
builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMainPageService, MainPageService>();

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
    name: "AreaMap",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
