﻿namespace WR.Consumers.Desktop.Domain.Commands.Users;

public sealed record class UpdateUserCommand : IRequest
{
    public User? User { get; }

    public UpdateUserCommand(User entity) =>
        User = entity;

    public UpdateUserCommand() { }
}