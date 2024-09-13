using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext appDbContext;

        public PlatformRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform != null)
            {
                appDbContext.Platforms.Add(platform);
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return appDbContext.Platforms.ToList();
        }

        public Platform GetPlatformByid(int id)
        {
            return appDbContext.Platforms.FirstOrDefault(s => s.Id == id);
        }


        public bool SaveChanges()
        {
            return appDbContext.SaveChanges() > 0;
        }
    }
}
