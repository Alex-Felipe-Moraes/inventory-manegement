using InventoyAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<InventoryContext>( options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddControllers();

builder.Services.AddCors( options =>
    options.AddPolicy("AllowAllOrigins",
        builder =>{
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }
    )

);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
