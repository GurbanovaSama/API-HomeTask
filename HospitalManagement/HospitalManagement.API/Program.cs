using FluentValidation.AspNetCore;
using FluentValidation;
using HospitalManagement.BL;
using HospitalManagement.BL.DTOs.PatientDtos;
using HospitalManagement.BL.Profiles.PatientProfiles;
using HospitalManagement.DAL.DAL;
using HospitalManagement.DAL.Repositories.Abstractions;
using HospitalManagement.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using HospitalManagement.BL.DTOs.InsuranceDtos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
builder.Services.AddBusinessServices();




builder.Services.AddAutoMapper(typeof(PatientProfile));
builder.Services.AddValidatorsFromAssembly(typeof(PatientCreateDtoValidation).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(InsuranceCreateDtoValidation).Assembly);
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
