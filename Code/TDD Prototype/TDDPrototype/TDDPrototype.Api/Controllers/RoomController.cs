using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using TDDPrototype.Api.Models;
using TDDPrototype.Api.Services;

namespace TDDPrototype.Api.Controllers
{
    public class RoomController : ControllerBase
    {
        private readonly IRoomDataService roomDataService;

        public RoomController(IRoomDataService roomDataService)
        {
            this.roomDataService = roomDataService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetByIdAsync(Guid id)
        {
            Room room = await roomDataService.GetByIdAsync(id);
            if (room is null)
            {
                return NotFound();
            }

            return room;
        }
    }
}