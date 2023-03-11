using AutoMapper;
using SimpleAPI.DAL.Entities;
using SimpleAPI.DTO.CustomerDTOs;

namespace SimpleAPI.BLL.Helpers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CustomerGetDto, Customer>().ReverseMap();
            CreateMap<CustomerAddDto, Customer>().ReverseMap();
        }
    }
}
