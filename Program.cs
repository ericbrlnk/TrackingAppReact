using Microsoft.EntityFrameworkCore;
using TrackingAppReact.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TrackingDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnTracking")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// allow communication from port 3000
app.UseCors(options => options.WithOrigins("http://localhost:3000")
.AllowAnyMethod()
.AllowAnyHeader()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
