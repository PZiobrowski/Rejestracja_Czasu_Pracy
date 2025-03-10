using Microsoft.EntityFrameworkCore;
using RCP.Database;
using RCP.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});


builder.Services.AddDbContext<RcpDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DateBaseConnection")));

builder.Services.AddScoped<IWorktimeManager, WorktimeManager>();

var port = builder.Configuration.GetValue<int>("Port");

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(port, listenOptions => listenOptions.UseHttps());
});

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

app.UseCors("AllowAll");

app.Run();
