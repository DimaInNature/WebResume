﻿namespace WR.Microservices.ContactMessageService.Domain.Commands;

public sealed record class CreateContactMessageCommand : IRequest
{
    public ContactMessageEntity? ContactMessage { get; }

	public CreateContactMessageCommand(ContactMessageEntity entity) => ContactMessage = entity;

	public CreateContactMessageCommand() { }
}
