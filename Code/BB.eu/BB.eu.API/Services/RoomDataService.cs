using System;
using System.Threading.Tasks;
using BB.eu.API.Data;
using BB.eu.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BB.eu.API.Services
{
    class RoomDataService : IRoomDataService
    {
        private readonly DataContextFactory contextFactory;

        public RoomDataService(DataContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<Room> CreateRoomAsync(Room room, Guid guid)
        {
            DataContext dataContext = contextFactory.CreateDbContext();

            var entity = await dataContext.Renters.FirstOrDefaultAsync(x => x.Guid == guid);
            entity.Rooms.Add(room);

            await dataContext.SaveChangesAsync();
            return room;
        }
    }
}