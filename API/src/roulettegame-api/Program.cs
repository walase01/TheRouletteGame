using Microsoft.EntityFrameworkCore;
using Persistence;
using roulettegame_api.ServiceLifetimes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var CONNECTION = Environment.GetEnvironmentVariable("USER_CONECTION") ?? "Server=localhost;Database=RouletteGame;Integrated Security=True;Encrypt=False;";

builder.Services.AddDbContext<UserDBContext>(option  => option.UseSqlServer(CONNECTION));

builder.Services.AddCors(o =>
{
    o.AddPolicy("BaseCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();      
    });
});

builder.Services.AddCustomServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("BaseCorsPolicy");

app.Run();
