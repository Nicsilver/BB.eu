using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BB.eu.API.Requests;
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
        public async Task<ActionResult<Renter>> CreateRenterAsync(
            [FromBody] RegisterAccountRequest registerRenterRequest)
        {
            Renter renter = mapper.Map<Renter>(registerRenterRequest);
            Renter result = await renterDataService.CreateAsync(renter);

            return result is null ? BadRequest("Email already exists") : result;
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
        public async Task<ActionResult<List<Renter>>> GetByIdAsync()
        {
            var renters = await renterDataService.GetAllAsync();

            return renters == null ? NotFound() : renters;
        }

        [HttpPut]
        [Route("Login")]
        public async Task<ActionResult<Renter>> LoginAsync([FromBody] LoginRequest entity)
        {
            Renter renter = await renterDataService.GetByEmailAsync(entity.Email);

            if (renter == null) return NotFound();
            return renter.Password == entity.Password ? renter : NotFound();
        }
    }
}