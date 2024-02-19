using Microsoft.EntityFrameworkCore;
using studentadminportal.Api.Data;
using studentadminportal.Api.Repositorys.Implemintation;
using studentadminportal.Api.Repositorys.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentAdminDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddScoped<IStudentRepositry,StudentRepositry>();
builder.Services.AddScoped<ICourseRepositry,CourseRepositry>();
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

app.Run();
