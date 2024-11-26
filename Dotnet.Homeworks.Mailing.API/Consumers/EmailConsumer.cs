using AutoMapper;
using Dotnet.Homeworks.Mailing.API.Dto;
using Dotnet.Homeworks.Mailing.API.Services;
using Dotnet.Homeworks.Shared.MessagingContracts.Email;
using MassTransit;

namespace Dotnet.Homeworks.Mailing.API.Consumers;

public class EmailConsumer : IEmailConsumer
{
    private readonly IMailingService _mailingService;
    private readonly IMapper _mapper;
    private readonly ILogger<EmailConsumer> _logger;

    public EmailConsumer(IMailingService mailingService, IMapper mapper, ILogger<EmailConsumer> logger)
    {
        _mailingService = mailingService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<SendEmail> context)
    {
        _logger.LogInformation($"Got email {context.Message.ReceiverEmail}");
        await _mailingService.SendEmailAsync(_mapper.Map<EmailMessage>(context.Message));
    }
}