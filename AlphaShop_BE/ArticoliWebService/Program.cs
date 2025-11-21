using ArticoliWebService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddDbContext<AlphaShopDbContext>();

builder.Services.AddScoped<IArticoliRepository,ArticoliRepository>();

var app = builder.Build();

app.UseRouting();
app.UseCors(options =>
    options
        .WithOrigins("http://localhost:4200")
        .WithMethods("POST","PUT","DELETE","GET")
        .AllowAnyHeader()
);
app.MapControllers();
app.Run();
