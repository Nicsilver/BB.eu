using System;
using System.Threading.Tasks;
using BB.eu.Shared.Models;

namespace BB.eu.API.Services
{
    public interface IRoomDataService
    {
        Task<Room> CreateRoomAsync(Room room, Guid guid);
    }
}