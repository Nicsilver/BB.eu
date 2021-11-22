using System;
using System.Threading.Tasks;
using TDDPrototype.Api.Models;

namespace TDDPrototype.Api.Services
{
    public interface IRoomDataService
    {
        Task<Room> GetByIdAsync(Guid id);
    }
}