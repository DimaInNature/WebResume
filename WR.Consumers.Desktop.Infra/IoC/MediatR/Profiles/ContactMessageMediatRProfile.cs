namespace WR.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

public static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        services.AddScoped<IRequest<IEnumerable<ContactMessage>>, GetContactMessageListQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageListQuery, IEnumerable<ContactMessage>>, GetContactMessageListQueryHandler>();

        services.AddScoped<IRequest<ContactMessage?>, GetContactMessageByIdQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>, GetContactMessageByIdQueryHandler>();

        #endregion

        #region Commands

        services.AddScoped<IRequest<ContactMessage?>, CreateContactMessageCommand>();
        services.AddScoped<IRequestHandler<CreateContactMessageCommand, ContactMessage?>, CreateContactMessageCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateContactMessageCommand>();
        services.AddScoped<IRequestHandler<UpdateContactMessageCommand, Unit>, UpdateContactMessageCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteContactMessageCommand>();
        services.AddScoped<IRequestHandler<DeleteContactMessageCommand, Unit>, DeleteContactMessageCommandHandler>();

        #endregion
    }
}