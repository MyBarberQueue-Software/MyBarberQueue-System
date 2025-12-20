using AutoMapper;
using MyBarberQueue_Web.API.Model.Domain;
using MyBarberQueue_Web.API.Models.Dtos;

namespace MyBarberQueue_Web.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Shop,ShopDto>().ReverseMap();
            CreateMap<AddShopRequestDto,Shop>().ReverseMap();
            CreateMap<UpdateShopRequestDto,Shop>().ReverseMap();

            CreateMap<Device,DeviceDto>().ReverseMap();
            CreateMap<AddDeviceRequestDto,Device>().ReverseMap();
            CreateMap<UpdateDeviceRequestDto,Device>().ReverseMap(); 
            
            CreateMap<Queue,QueueDto>().ReverseMap();
            CreateMap<AddQueueRequestDto,Queue>().ReverseMap();
            CreateMap<UpdateQueueRequestDto,Queue>().ReverseMap();

            CreateMap<Ticket,TicketDto>().ReverseMap();
            CreateMap<AddTicketRequestDto,Ticket>().ReverseMap();
            CreateMap<UpdateTicketRequestDto,Ticket>().ReverseMap();

            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<AddUserRequestDto,User>().ReverseMap();
            CreateMap<UpdateUserRequestDto,User>().ReverseMap();
        }
    }
}
