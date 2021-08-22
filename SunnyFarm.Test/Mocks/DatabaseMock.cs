namespace SunnyFarm.Test.Mocks
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SunnyFarm.Data;
    
    public static class DatabaseMock
    {
        public static SunnyFarmDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<SunnyFarmDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new SunnyFarmDbContext(dbContextOptions);
            }
                
        }
    }
}
