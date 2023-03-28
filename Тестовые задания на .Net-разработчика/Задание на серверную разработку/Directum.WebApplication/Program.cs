using Database;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
         options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ChatDatabase;Trusted_Connection=true"));

builder.Services.AddTransient<IGenericRepository<User>, EFGenericRepository<User>>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IGenericRepository<Contact>, EFGenericRepository<Contact>>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IGenericRepository<Message>, EFGenericRepository<Message>>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
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
