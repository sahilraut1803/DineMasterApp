using AutoMapper;
using DineMaster_APICreation.Data;
using DineMaster_APICreation.Mapping;
using DineMaster_APICreation.Repository;
using DineMaster_APICreation.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>
    (
        Options => Options.UseSqlServer
        (
            builder.Configuration.GetConnectionString("myConn")
        )
    );
builder.Services.AddScoped<IUserRepo, UserServices>();
builder.Services.AddScoped<ITableRepo, TableService>();
builder.Services.AddScoped<IReservationRepo, ReservationService>();

builder.Services.AddAutoMapper(typeof(MappingData));

builder.Services.AddCors(options =>
{
    options.AddPolicy("App", policy =>
    {
        policy.WithOrigins("http://localhost:4200")// consuming app
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // required for cookies
    });
});

var app = builder.Build();

app.UseCors("App");

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
