using PlatformService.Data.Dtos;
using System.Text;
using System.Text.Json;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace PlatformService.SyncDataServices.http
{
    public class CommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            try
            {
                var httpContent = new StringContent(JsonSerializer.Serialize(plat), encoding: Encoding.UTF8, mediaType: "application/json");

                Console.WriteLine("--> httpContent 5001" + httpContent);
                var url = $"{_configuration["CommandServiceUrl"]}";
                Console.WriteLine("--> url" + url);

                var response = await _httpClient.PostAsync($"{_configuration["CommandServiceUrl"]}", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("--> Sync POST to CommandService was OK!");
                }
                else
                {
                    Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
                }

            }
            catch (Exception ex)
            {
                // Print the top-level exception details
                Console.WriteLine("--> Exception: " + ex.Message);
                Console.WriteLine("--> Stack Trace: " + ex.StackTrace);

                // Loop through the inner exceptions (if any)
                Exception innerEx = ex.InnerException;
                int level = 1;
                while (innerEx != null)
                {
                    Console.WriteLine($"--> Inner Exception Level {level}: " + innerEx.Message);
                    Console.WriteLine($"--> Inner Exception Level {level} Stack Trace: " + innerEx.StackTrace);
                    innerEx = innerEx.InnerException;
                    level++;
                }
            }
        }
    }
}
