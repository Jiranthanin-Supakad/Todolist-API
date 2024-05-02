using WebApiDemo.Models;
using WebApiDemo.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace WebApiDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // builder.Services.AddAuthentication("BasicAuthentication")
        //     .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            
        builder.Services.AddScoped<ITodoService, TodoService>();

        builder.Services.AddControllers();
        builder.Services.AddDbContext<WebApiDemoContext>(opt => 
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
    }
}
