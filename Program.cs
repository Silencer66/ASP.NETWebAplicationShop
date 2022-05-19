using ASP.NETWebAplicationShop.Data.Interfaces;
using ASP.NETWebAplicationShop.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using ASP.NETWebAplicationShop.Data.Repository;
using ASP.NETWebAplicationShop.Data.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp=>ShopCart.GetCart(sp));

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

//Отображаем страничку с ошибками
app.UseDeveloperExceptionPage();

//Код ошибки
app.UseStatusCodePages();

//подключаем использование статических файлов 
//благодаря этому можем отображать css файлы, картинки и т.д.
app.UseStaticFiles();
app.UseSession();
//мы можем отслеживать url-addres(в случае чего отображать url по умолчанию)
//app.UseMvcWithDefaultRoute();
app.UseMvc(routes =>
{
    //по умолчанию контроллер будет вывзван контроллер Home и функция Index
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
});

using(var context = new AppDBContext())
{
    DBObjects.Initial(context);
}
//app.UseRouting();
app.MapGet("/", () => "Hello World!");
app.Run();