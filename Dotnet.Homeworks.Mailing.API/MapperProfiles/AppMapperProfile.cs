using AutoMapper;
using Dotnet.Homeworks.Mailing.API.Dto;
using Dotnet.Homeworks.Shared.MessagingContracts.Email;

namespace Dotnet.Homeworks.Mailing.API.MapperProfiles;

public class AppMapperProfile : Profile
{
    public AppMapperProfile()
    {
        CreateMap<SendEmail, EmailMessage>()
            .ForMember(dest => dest.Email, 
                opt => 
                opt.MapFrom(src => src.ReceiverEmail))
            .ConstructUsing(src => new EmailMessage(src.ReceiverEmail, src.Subject, src.Content));
    }
}