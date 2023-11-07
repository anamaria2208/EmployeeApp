using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options => {
    options.AddPolicy("ClientApp",
                          policy =>
                          {
                              policy.WithOrigins("https://localhost:6000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

// REGISTER DB CONTEXT
builder.Services.AddDbContext<CompanyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyDatabase")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ClientApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
