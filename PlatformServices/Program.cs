using Microsoft.EntityFrameworkCore;
using PlatformService.AsynDataService;
using PlatformService.Data;
using PlatformService.SyncDataServices.Grpc;
using PlatformService.SyncDataServices.http;

namespace PlatformService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5000); // Configure the application to listen on port 5000
            });


            if (builder.Environment.IsProduction())
            {
                Console.WriteLine("--> Using SqlServer Db");
                builder.Services.AddDbContext<AppDbContext>(opt =>
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));
            }
            else
            {
                Console.WriteLine("--> Using InMem Db");
                builder.Services.AddDbContext<AppDbContext>(opt =>
                     opt.UseInMemoryDatabase("InMem"));
            }
            builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
            builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
            builder.Services.AddHttpClient<ICommandDataClient, CommandDataClient>();
            builder.Services.AddGrpc();


            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.MapGrpcService<GrpcPlatformService>();
            app.MapControllers();

            PrepDb.PrepPopulation(app, app.Environment.IsProduction());

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapGrpcService<GrpcPlatformService>();

                endpoints.MapGet("/protos/platforms.proto", async context =>
                {
                    await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
                });

            });
           
            app.Run();
        }
    }
}
