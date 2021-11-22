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
    public class TenantController : ControllerBase
    {
        private readonly ITenantDataService tenantDataService;
        private readonly IMapper mapper;

        public TenantController(ITenantDataService tenantDataService, IMapper mapper)
        {
            this.tenantDataService = tenantDataService;
            this.mapper = mapper;
        }

        [HttpPut]
        [Route("Create")]
        public async Task<ActionResult<Tenant>> CreateRenterAsync(
            [FromBody] RegisterAccountRequest registerRenterRequest)
        {
            Tenant tenant = mapper.Map<Tenant>(registerRenterRequest);
            Tenant result = await tenantDataService.CreateAsync(tenant);

            return result is null ? BadRequest() : result;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<Tenant>> GetByIdAsync(int id)
        {
            Tenant tenant = await tenantDataService.GetByIdAsync(id);

            return tenant == null ? NotFound() : tenant;
        }
    }
}