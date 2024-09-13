
using CommandService.Data;
using CommandsService.AsyncDataServices;
using CommandsService.Data;
using CommandsService.EventProcessing;
using CommandsService.SyncDataServices.Grpc;
using Microsoft.EntityFrameworkCore;

namespace CommandService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.ListenAnyIP(5001); // Configure the application to listen on port 5000
            //});
            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMen"));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICommandRepo, CommandRepo>();
            builder.Services.AddSingleton<IEventProcessor, EventProcessor>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
          
            builder.Services.AddHostedService<MessageBusSubscriber>();
            builder.Services.AddScoped<IPlatformDataClient, PlatformDataClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            PrepDb.PrepPopulation(app);

            app.Run();
        }
    }
}
