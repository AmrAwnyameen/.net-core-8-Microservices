using PlatformService.Data.Dtos;

namespace PlatformService.SyncDataServices.http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}
