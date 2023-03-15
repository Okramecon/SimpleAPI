using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SimpleAPI.Api.Extensions;
using SimpleAPI.Api.Middlwares;
using SimpleAPI.BLL.Helpers;
using SimpleAPI.DAL;

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

builder.Services.AddAuthorization();
builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
            options.Events.OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = 403;
                return Task.CompletedTask;
            };
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            };
        }
    );

builder.Services.Configure<CookieAuthenticationOptions>(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Events.OnRedirectToAccessDenied = new Func<RedirectContext<CookieAuthenticationOptions>, Task>(context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return context.Response.CompleteAsync();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
