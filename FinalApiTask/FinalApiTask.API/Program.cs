using FinalApiTask.BL;
using FinalApiTask.DAL.DAL;
using FinalApiTask.DAL.Repositories.Abstractions;
using FinalApiTask.DAL;
using FinalApiTask.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using FinalApiTask.BL.Profiles.ProductProfiles;
using FinalApiTask.BL.DTOs.ProductDtos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDALServices();
builder.Services.AddBLServices();


builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddValidatorsFromAssembly(typeof(ProductCreateDtoValidation).Assembly);
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
