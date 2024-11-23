using Dotnet.Homeworks.Shared.MessagingContracts.Email;
using MassTransit;

namespace Dotnet.Homeworks.MainProject.Services;

public class CommunicationService : ICommunicationService
{
    private readonly IBus _bus;
    private readonly ILogger<CommunicationService> _logger;

    public CommunicationService(IBus bus, ILogger<CommunicationService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public async Task SendEmailAsync(SendEmail sendEmailDto)
    {
        _logger.LogInformation($"Sending email {sendEmailDto.ReceiverEmail}");
        await _bus.Publish(sendEmailDto);
    }
}