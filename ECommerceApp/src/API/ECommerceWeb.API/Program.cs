using ECommerceWeb.API.Middleware;
using ECommerceWeb.Infrastructure;
using ECommerceWeb.Application;
using ECommerceWeb.Identity;


namespace ECommerceWeb.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddApplicationServices();
            builder.Services.AddInterfaceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors(x => x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
