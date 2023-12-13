using AutoMapper;
using CmcMarkets.Backend.Core.Entities;

namespace CmcMarkets.Backend.Service.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserTask, UserTaskDto>().ReverseMap();
        }
    }
}
