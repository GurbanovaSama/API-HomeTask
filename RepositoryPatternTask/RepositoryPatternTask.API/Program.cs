using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternTask.BL;
using RepositoryPatternTask.BL.DTOs.EmployeeDtos;
using RepositoryPatternTask.BL.Profiles.EmployeeProfiles;
using RepositoryPatternTask.BL.Services.Abstractions;
using RepositoryPatternTask.BL.Services.Implementations;
using RepositoryPatternTask.Core.Entities;
using RepositoryPatternTask.DAL.DAL;
using RepositoryPatternTask.DAL.Repositories.Abstractions;
using RepositoryPatternTask.DAL.Repositories.Implementations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddBusinessServices();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    {
        opt.Password.RequiredLength = 8;
        opt.User.RequireUniqueEmail = true;
        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        opt.Lockout.MaxFailedAccessAttempts = 3;
    }
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();





builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddValidatorsFromAssembly(typeof(EmployeeCreateDtoValidation).Assembly);
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

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
