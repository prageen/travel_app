
using AutoMapper;
using Travel.Dto;
using Travel.Dto.Trip;
using Travel.Infrastructure;

namespace Travel.Api.Mapper
{
    public class AutoMapperUser : Profile
    {
        public AutoMapperUser()
        {
            CreateMap<VehicleMasterDto, VehicleMaster>().ReverseMap();
            CreateMap<PartyDto, Party>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<DriverDto, Driver>().ReverseMap();
            CreateMap<TripCategoryDto, TripCategory>().ReverseMap();
            CreateMap<TripExpenceDto, TripExpence>().ReverseMap();
            CreateMap<VehicleExpenceDto, VehicleExpence>().ReverseMap();
            CreateMap<StateDto, State>().ReverseMap();
            CreateMap<DistrictDto, District>().ReverseMap();
            CreateMap<LocationDto, Location>().ReverseMap();
        }
    }
}
