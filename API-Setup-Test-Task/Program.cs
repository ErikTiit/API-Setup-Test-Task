using Microsoft.EntityFrameworkCore;
using API_Setup_Test_Task.Models;
using API_Setup_Test_Task.Repository;
using API_Setup_Test_Task.IRepository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers()
            .AddNewtonsoftJson();
builder.Services.AddDbContext<CarContext>(opt =>
    opt.UseInMemoryDatabase("Vehicles")); // specifying for the database context to use an in-memory database
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>(); // specifying the repo interface
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
