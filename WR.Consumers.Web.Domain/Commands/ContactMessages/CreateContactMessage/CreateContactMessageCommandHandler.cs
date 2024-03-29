﻿namespace WR.Consumers.Web.Domain.Commands.ContactMessages;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand, ContactMessage?>
{
    private readonly IConfiguration _configuration;

    public CreateContactMessageCommandHandler(IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<ContactMessage?> Handle(
        CreateContactMessageCommand request,
        CancellationToken token)
    {
        if (request.ContactMessage is null) return null;

        HttpSender sender = new(hostUri: _configuration[key: "Routes:Gateway"]);

        var result = await sender.PostAndReturnAsync(
            routePath: _configuration[key: "Routes:ContactMessages:CreateContactMessage"],
            serializableObj: request.ContactMessage,
            cancellationToken: token);

        return result;
    }
}