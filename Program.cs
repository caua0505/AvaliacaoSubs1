using ApiProjeto.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// SQL Server 
builder.Services.AddDbContext<AppDnContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Controllers

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger

app.UseSwagger();
app.UseSwaggerUI();

//CORS
app.UseCors("AllowAll");

app.MapGet("/", () => "API Rodando!");

app.MapControllers();

app.Run();