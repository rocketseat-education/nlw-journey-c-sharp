using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<JourneyDbContext>(options => options.UseSqlite("Data Source=src/Journey.Infrastructure/JourneyDatabase.db"));
// builder.Services.AddDbContext<JourneyDbContext>(options => options.UseSqlite("JourneyDbContext"));

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