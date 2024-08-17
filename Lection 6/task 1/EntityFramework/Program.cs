using BLL.Extensions;
using DataLayer;
using DataLayer.Data;
using task_1.Data;
using task_1.Data.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataAccessLayer(builder.Configuration);
// Injection ^^^ DAL

builder.Services.AddBusinessLogicLayer();
// Injection ^^^ BLL

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<WebStorageDbContext>();
        DbInitializer.InitializeDataBase(context);
    }
    catch (Exception)
    {
        throw;
    }
}

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var seeder = serviceProvider.GetRequiredService<DataSeeder>();
        await seeder.Seed();
    }
    catch (Exception)
    {
        throw;
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
