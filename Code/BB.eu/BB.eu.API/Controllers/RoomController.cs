using System;
using System.Threading.Tasks;
using AutoMapper;
using BB.eu.API.Services;
using BB.eu.Shared.Models;
using BB.eu.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BB.eu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomDataService dataDataService;
        private readonly IMapper mapper;

        public RoomController(IRoomDataService dataDataService, IMapper mapper)
        {
            this.dataDataService = dataDataService;
            this.mapper = mapper;
        }

        [HttpPut]
        [Route("Create")]
        public async Task<ActionResult<Room>> CreateRoomAsync([FromBody] CreateRoomRequest request)
        {
            Room room = mapper.Map<Room>(request);
            Guid guid = request.Guid;

            return await dataDataService.CreateRoomAsync(room, guid);
        }
    }
}