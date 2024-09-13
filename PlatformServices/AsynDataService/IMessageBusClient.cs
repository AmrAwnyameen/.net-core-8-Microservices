using PlatformService.Dtos;

namespace PlatformService.AsynDataService
{
    public interface IMessageBusClient
    {
        void PublishNewPlatform(PlatformPublishedDto platformPublishedDto);
    }
}
