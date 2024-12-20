using Microsoft.EntityFrameworkCore;
using WorkShopManagement.BL.Services.Abstractions;
using WorkShopManagement.BL.Services.Implementations;
using WorkShopManagement.DAL.DAL;
using WorkShopManagement.DAL.Repositories.Abstractions;
using WorkShopManagement.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IWorkShopRepository, WorkShopRepository>();


builder.Services.AddScoped<IParticipantService, ParticipantService>();

builder.Services.AddScoped<IWorkShopService, WorkShopService>();


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
