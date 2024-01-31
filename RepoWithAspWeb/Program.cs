using BusinessLayer;
using DataAccess;
using DataAccess.Data;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped(typeof(ICustomerRepo),typeof(CustomerRepo));
builder.Services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
builder.Services.AddScoped<IProductRepo,ProductRepo>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IOrderItemRepo, OrderItemRepo>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddSession();
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
    pattern: "{controller=Product}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);

app.Run();
