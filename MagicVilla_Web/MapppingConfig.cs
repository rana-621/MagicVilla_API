using AutoMapper;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web
{
    public class MapppingConfig : Profile
    {
        public MapppingConfig()
        {
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();


            CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();

        }
    }
}
