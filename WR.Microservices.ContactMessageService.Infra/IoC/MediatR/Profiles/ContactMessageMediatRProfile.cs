namespace WR.Microservices.ContactMessageService.Infra.IoC.MediatR.Profiles;

public static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        services.AddTransient<IRequest<Unit>, CreateContactMessageCommand>();
        services.AddTransient<IRequestHandler<CreateContactMessageCommand, Unit>, CreateContactMessageCommandHandler>();

        services.AddTransient<IRequest<Unit>, UpdateContactMessageCommand>();
        services.AddTransient<IRequestHandler<UpdateContactMessageCommand, Unit>, UpdateContactMessageCommandHandler>();

        services.AddTransient<IRequest<Unit>, DeleteContactMessageCommand>();
        services.AddTransient<IRequestHandler<DeleteContactMessageCommand, Unit>, DeleteContactMessageCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<IEnumerable<ContactMessageEntity>>, GetContactMessagesListQuery>();
        services.AddScoped<IRequestHandler<GetContactMessagesListQuery, IEnumerable<ContactMessageEntity>>, GetContactMessagesListQueryHandler>();

        services.AddScoped<IRequest<ContactMessageEntity?>, GetContactMessageByIdQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageByIdQuery, ContactMessageEntity?>, GetContactMessageByIdQueryHandler>();

        #endregion
    }
}