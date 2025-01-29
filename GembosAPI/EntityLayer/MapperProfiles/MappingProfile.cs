using AutoMapper;
using GembosAPI.EntityLayer.DTOs;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.EntityLayer.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();

            CreateMap<CreateMessageDTO, Message>();
            CreateMap<Message, CreateMessageDTO>();
        }
    }
}
