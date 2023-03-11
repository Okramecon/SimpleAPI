using SimpleAPI.Api.Extensions;
using SimpleAPI.Api.Middlwares;
using SimpleAPI.BLL.Helpers;

var builder = WebApplication.CreateBuilder(args);

//var configuration = builder.Configuration
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//    .Build();

// Add services to the container.

builder.Services.RegisterBllServices();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterRepositories();
builder.Services.AddAutoMapper(config => config.AddProfile<MapProfile>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
