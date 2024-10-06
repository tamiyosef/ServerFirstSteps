using Microsoft.EntityFrameworkCore;
using TaskManagmentServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 // חיבור למסד הנתונים
builder.Services.AddDbContext<TasksManagementDbContext>(
                   options => options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Initial Catalog = TasksManagementDB; User ID = TaskAdminLogin; Password = kukuPassword; Trusted_Connection = True; MultipleActiveResultSets = true"));

// הוספת תמיכה בסשן
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = false;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession(); //In order to enable session management


app.UseAuthorization();

app.MapControllers();

app.Run();
