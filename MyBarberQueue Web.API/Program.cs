// Add this using directive
using Microsoft.EntityFrameworkCore;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Mappings;
using MyBarberQueue_Web.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at aka.ms
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection Connection String and DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injecting Respositories
builder.Services.AddScoped<IShopRepository, SqlShopRepository>();
builder.Services.AddScoped<IDeviceRepository, SqlDeviceRepository>();
builder.Services.AddScoped<IQueueRepository, SqlQueueRepository>();

// Inject autoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Optional: set Swagger UI as the app's root page
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBarberQueue V1 API");
    // c.RoutePrefix = string.Empty; 
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
