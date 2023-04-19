using API.Models;
using Application.Commands.CreateProject;
using Application.Services.Implementations;
using Application.Services.Interfaces;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<DevFreelanceDbContext>();
var connectionString = builder.Configuration.GetConnectionString("DevFreelanceCs");
builder.Services.AddDbContext<DevFreelanceDbContext>(options => options.UseSqlServer(connectionString));
// builder.Services.AddDbContext<DevFreelanceDbContext>(options => options.UseInMemoryDatabase("DevFreelance"));

//scopes
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateProjectCommand));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
