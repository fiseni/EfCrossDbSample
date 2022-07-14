using EfCrossDbSample;
using EfCrossDbSample.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection1")));

// In this sample we're using this additional context for the second DB just so we can seed some test data.
builder.Services.AddDbContext<AppDbContext2>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection2")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.Services.SeedTestData();

app.Run();
