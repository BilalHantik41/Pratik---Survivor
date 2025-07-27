using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pratik___Survivor.Context;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // "v1" adında bir Swagger dokümanı tanımlıyoruz
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Survivor API",
        Version = "v1",
        Description = "Survivor API dokümantasyonu"
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SurvivorDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Bu sayfa, HTTP 500 gibi hatalarda detaylı exception bilgisi gösterir.
    app.UseDeveloperExceptionPage();
}

// Middleware’lar
app.UseHttpsRedirection();

// Swagger JSON endpoint’ini sun
app.UseSwagger();

// Swagger UI’ı ana dizine taşı
app.UseSwaggerUI(c =>
{
    // Swagger JSON dosyasının yolu ve başlık
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Survivor API V1");
    // RoutePrefix boş olursa UI doğrudan "/" adresinde sunulur
    c.RoutePrefix = string.Empty;
});
app.MapControllers();
app.Run();