using Dotnet.Homeworks.Mailing.API.Configuration;
using Dotnet.Homeworks.Mailing.API.MapperProfiles;
using Dotnet.Homeworks.Mailing.API.Services;
using Dotnet.Homeworks.Mailing.API.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

builder.Services.AddAutoMapper(mapper =>
{
    mapper.AddProfile<AppMapperProfile>();
});
builder.Services.AddScoped<IMailingService, MailingService>();
builder.Services.AddMasstransitRabbitMq(
    builder.Configuration.GetSection("RabbitConfig").Get<RabbitMqConfig>()!);

var app = builder.Build();

app.Run();