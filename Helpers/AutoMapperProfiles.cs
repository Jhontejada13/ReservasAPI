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
        }
    }
}
