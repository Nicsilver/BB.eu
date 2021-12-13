using AutoMapper;
using BB.eu.API.Responses;
using BB.eu.Shared.Models;
using BB.eu.Shared.Requests;

namespace BB.eu.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterAccountRequest, Renter>();
            CreateMap<RegisterAccountRequest, Tenant>();
            CreateMap<LoginRequest, Renter>();
            CreateMap<LoginRequest, Tenant>();
            CreateMap<Renter, RenterCreateResponse>();
            CreateMap<Renter, RenterGetAllResponse>();
            CreateMap<CreateRoomRequest, Room>();
            CreateMap<Renter, RenterLoginResponse>();
        }
    }
}