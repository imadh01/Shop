using Microsoft.EntityFrameworkCore;
using Shop.DataHub;
using Shop.DataHub.Repositary;
using Shop.Service.BusinessLogic;
using Shop.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnectionString")));
builder.Services.AddTransient<IProductData, ProductData>();
builder.Services.AddTransient<ICouponData, CouponData>();
builder.Services.AddTransient<ISupplierData, SupplierData>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICouponService, CouponService>();
builder.Services.AddTransient<ISupplierService, SupplierService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
