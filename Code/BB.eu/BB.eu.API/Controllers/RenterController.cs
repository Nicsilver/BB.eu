using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BB.eu.API.Requests;
using BB.eu.API.Responses;
using BB.eu.API.Services;
using BB.eu.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BB.eu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RenterController : ControllerBase
    {
        private readonly IRenterDataService renterDataService;
        private readonly IMapper mapper;

        public RenterController(IRenterDataService renterDataService, IMapper mapper)
        {
            this.renterDataService = renterDataService;
            this.mapper = mapper;
        }

        [HttpPut]
        [Route("Create")]
        public async Task<ActionResult<RenterCreateResponse>> CreateRenterAsync(
            [FromBody] RegisterAccountRequest registerRenterRequest)
        {
            Renter renter = mapper.Map<Renter>(registerRenterRequest);
            Renter result = await renterDataService.CreateAsync(renter);

            return result is null ? BadRequest("Email already exists") : mapper.Map<RenterCreateResponse>(result);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Renter>> GetByIdAsync(int id)
        {
            Renter renter = await renterDataService.GetByIdAsync(id);

            return renter == null ? NotFound() : renter;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<RenterGetAllResponse>>> GetAllAsync()
        {
            var renters = await renterDataService.GetAllAsync();

            return renters == null ? NotFound() : mapper.Map<List<RenterGetAllResponse>>(renters);
        }

        [HttpPut]
        [Route("Login")]
        public async Task<ActionResult<RenterLoginResponse>> LoginAsync([FromBody] LoginRequest entity)
        {
            Renter renter = await renterDataService.GetByEmailAsync(entity.Email);

            if (renter == null) return NotFound();
            return renter.Password == entity.Password ? mapper.Map<RenterLoginResponse>(renter) : NotFound();
        }

        //TODO maybe create room should live in its own controller, this goes for a dataservice
        // as well should renter service be able to create a room?
        [HttpPut]
        [Route("CreateRoom")]
        public async Task<ActionResult<Room>> CreateRoomAsync([FromBody] CreateRoomRequest request)
        {
            Room room = mapper.Map<Room>(request);
            Guid guid = request.Guid;

            return await renterDataService.CreateRoomAsync(room, guid);
        }
    }
}