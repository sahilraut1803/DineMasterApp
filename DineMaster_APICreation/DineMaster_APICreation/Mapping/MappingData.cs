using AutoMapper;
using DineMaster_APICreation.DTO;
using DineMaster_APICreation.Models;

namespace DineMaster_APICreation.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<Table, TableDTO1>().ReverseMap();
            CreateMap<Table, TableDTO2>().ReverseMap();
            CreateMap<Table, TableDTO3>().ReverseMap();

            CreateMap<Reservation, ReservationDTO1>().ReverseMap();
            CreateMap<Reservation, ReservationDTO2>()
            .ForMember(dest => dest.Tname, opt => opt.MapFrom(src => src.Table != null ? src.Table.Name : "")).ReverseMap();
            CreateMap<Reservation, ReservationDTO3>().ReverseMap();

            CreateMap<Order, OrderDTO1>().ReverseMap();
        }
    }
}
