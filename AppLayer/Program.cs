using BLL.Services;
using DAL;
using DAL.EF;
using DAL.EF.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Dependency Inject

//CategoryService depends on CategoryRepo
builder.Services.AddScoped<CategoryRepo>();
//CategoryController depends on CategoryService
builder.Services.AddScoped<CategoryService>();
//BookService depends on BookRepo
builder.Services.AddScoped<BookRepo>();
//BookController depends on BookService
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<DataFactory>();
builder.Services.AddDbContext<UMSContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
