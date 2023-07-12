using System.Text.Json.Serialization;
using Sportex.Infrastructure.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Using SQL Database
var connectionString = builder.Configuration["ConnectionStrings:Connection"];
DIRegistration.RegisterDBContext(builder, connectionString);

// Dependency Injection
DIRegistration.RegisterDI(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seeds the database
DbInitializer.Seed(app);

app.Run();