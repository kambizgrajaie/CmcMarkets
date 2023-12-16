using AutoMapper;
using CmcMarkets.Backend.Core.Entities;

namespace CmcMarkets.Backend.Core.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserTask, UserTaskDto>().ReverseMap();
        }
    }
}
