using Microsoft.EntityFrameworkCore;
using TaskTracker.Application;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Services;
using TaskTracker.Infrastructure.Data;
using TaskTracker.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// ----------------------
// Database
// ----------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----------------------
// Repositories & Services
// ----------------------
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

// ----------------------
// MediatR (CQRS)
// ----------------------
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly);
});

// ----------------------
// AutoMapper (15.x)
// ----------------------
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(ApplicationMarker).Assembly);
});

// ----------------------
// Controllers & Swagger
// ----------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------
// Middleware
// ----------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
