using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using WebApi;
using WebApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// 🔹 Configuración de DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// 🔹 Inyección de dependencias para tu repositorio
builder.Services.AddScoped<IPaymentRequestRepository, PaymentRequestRepository>();

// 🔹 Controladores
builder.Services.AddControllers();

// 🔹 Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WebApi",
        Version = "v1",
        Description = "API de pagos con EF Core y repositorio"
    });
});

var app = builder.Build();

// 🔹 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz (https://localhost:5001/)
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); 
app.UseAuthorization();
app.MapControllers();
app.Run();
