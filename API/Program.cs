using Application.Commands.CreateProject;
using Application.Validators;
using Core.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
// Database
var connectionString = builder.Configuration.GetConnectionString("DevFreelanceCs");
builder.Services.AddDbContext<DevFreelanceDbContext>(options => options.UseSqlServer(connectionString));

// Repositories
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Mediator for CQRS
builder.Services.AddMediatR(typeof(CreateProjectCommand));

builder.Services.AddControllers();
builder.Services
  .AddValidatorsFromAssemblyContaining<CreateUserValidator>()
  .AddFluentValidationAutoValidation()
  .AddFluentValidationClientsideAdapters();

// Initiate Swagger configs
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
