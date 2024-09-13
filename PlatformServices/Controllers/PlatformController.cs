using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.AsynDataService;
using PlatformService.Data;
using PlatformService.Data.Dtos;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
         readonly IPlatformRepo _repository;
         readonly IMapper _mapper;
         readonly ICommandDataClient _commandDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsController(
              IPlatformRepo repository,
              IMapper mapper, ICommandDataClient commandDataClient, IMessageBusClient messageBusClient)
           
        {
            _repository = repository;
            _mapper = mapper;
            this._commandDataClient = commandDataClient;
            this._messageBusClient = messageBusClient;
        }

        [HttpGet("GetPlatForms")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatForms()
        {
            Console.WriteLine("=> Get All PlatForms.......");
            var platforms = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }


        [HttpGet("{platformId}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById([FromRoute]int platformId)
        {
            Console.WriteLine("=> Get  PlatForm by Id.......");
            var platform = _repository.GetPlatformByid(platformId);
            if (platform != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platform));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("CreatePlatform")]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform([FromBody] PlatformCreateDto model)
        {
            Console.WriteLine("=> Get new  Platform ......");

            var platform = _mapper.Map<Platform>(model);
            _repository.CreatePlatform(platform);

            var platformReadDto = _mapper.Map<PlatformReadDto>(platform);

            try
            {
               await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex?.InnerException?.Message);
            }

            //Send Async Message
            try
            {
                var platformPublishedDto = _mapper.Map<PlatformPublishedDto>(platformReadDto);
                platformPublishedDto.Event = "Platform_Published";
                _messageBusClient.PublishNewPlatform(platformPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            if (_repository.SaveChanges())
            {
                return CreatedAtRoute(nameof(GetPlatformById), new { platformId = platformReadDto.Id }, platformReadDto);
            }
            return NotFound();
        }




    }
}
