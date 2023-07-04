using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up DB SQLite connection
builder.Services.AddDbContext<DatabaseContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register a mediatr 
builder.Services.AddMediatR(typeof(Application.Tasks.ListAll.Handler));

// ADD CORS POLICY
builder.Services.AddCors(options => {
        
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// USE CORS POLICY
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
