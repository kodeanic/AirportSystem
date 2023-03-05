using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;

namespace WebApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Airplane, AirplaneDto>();

        CreateMap<Flight, FlightDto>()
            .ForMember(x => x.TypeAirplane, o => o.MapFrom(f => f.Airplane.TypeAirplane));

        CreateMap<Schedule, ScheduleDto>()
            .ForMember(x => x.Flight, o => o.MapFrom(s => s.Flight.Name))
            .ForMember(x => x.Hours, o => o.MapFrom(s => s.Time.Hour))
            .ForMember(x => x.Minutes, o => o.MapFrom(s => s.Time.Minute));

        //

        // ----

        CreateMap<AirplaneDto, Airplane>();

        CreateMap<FlightDto, Flight>()
            .ForMember(x => x.Airplane, o => o.Ignore());

        CreateMap<ScheduleDto, Schedule>()
            .ForMember(x => x.Flight, o => o.Ignore())
            .ForMember(x => x.Time, o => o.Ignore());
    }
}
