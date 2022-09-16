using AutoMapper;
using ReservasAPI.Data.DTOs;
using ReservasAPI.Data.Entities;

namespace ReservasAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Turista, TuristaDto>().ReverseMap();
            CreateMap<TuristaCreacionDto, Turista>();

            CreateMap<Sucursal, SucursalDto>().ReverseMap();
            CreateMap<SucursalCreacionDto, Sucursal>();

            CreateMap<ReservaHotel, ReservaHotelDto>().ReverseMap();
            CreateMap<ReservaHotelCreacionDto, ReservaHotel>();

            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<HotelCreacionDto, Hotel>();

            CreateMap<ContratoSucursal, ContratoSucursalDto>().ReverseMap();
            CreateMap<ContratoSucursalCreacionDto, ContratoSucursal>();
        }
    }
}
