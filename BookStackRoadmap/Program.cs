using System.Runtime.CompilerServices;
using BookStackRoadmap.Data.Repositories;
using BookStackRoadmap.Services;


namespace BookStackRoadmap;

public class Program
{
    public static void Main(string[] args)
    {
        
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
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

        app.UseAuthorization();

    
        app.MapControllers();

        app.Run();
    }

    private static void InjectServices(IServiceCollection services)
    {
        services.AddTransient<IRoadmapService, RoadmapService>();
    }

    private static void InjectRepositories(IServiceCollection services)
    {
        services.AddScoped<IRoadmapTaskRepository, RoadmapTaskRepository>();
        services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
    }
}