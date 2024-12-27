using ECommerceApi.BL.Profiles.OrderItemProfiles;
using ECommerceApi.BL.Profiles.OrderProfiles;
using ECommerceApi.BL.Profiles.ProductProfiles;
using ECommerceApi.BL.Services;
using ECommerceApi.DAL.DAL;
using ECommerceApi.DAL.Repositories.Abstractions;
using ECommerceApi.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();    
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddBusinessServices();



builder.Services.AddAutoMapper(typeof(OrderItemProfile));
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddAutoMapper(typeof(
    ProductProfile));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});

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
