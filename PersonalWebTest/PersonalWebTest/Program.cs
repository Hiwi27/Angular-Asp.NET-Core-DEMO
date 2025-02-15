
using Microsoft.EntityFrameworkCore;
using PersonalWebTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conection to Database with Database Context
builder.Services.AddDbContext<ContactsDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//For Testing
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

//For Production
//app.UseCors(policy => policy.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
