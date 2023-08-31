using AutoMapper;
using Chat.Application.Dtos.ActiveUser;
using Chat.Domain.Entities;

namespace Chat.Api.Mappings
{
    public class ActiveUserMappings : Profile
    {
        public ActiveUserMappings()
        {
            CreateMap<GetActiveUserDto, ActiveUser>().ReverseMap();

            CreateMap<CreateActiveUserDto, ActiveUser>().ReverseMap();

            CreateMap<UpdateActiveUserDto, ActiveUser>().ReverseMap();
        }
    }
}
