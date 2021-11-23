using AutoMapper;
using BB.eu.API.Requests;
using BB.eu.Shared.Models;

namespace BB.eu.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterAccountRequest, Renter>();
            CreateMap<RegisterAccountRequest, Tenant>();
            CreateMap<LoginRequest, Tenant>();
        }
    }
}