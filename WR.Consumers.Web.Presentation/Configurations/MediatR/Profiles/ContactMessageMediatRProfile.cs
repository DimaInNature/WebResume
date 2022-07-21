namespace WR.Consumers.Web.Presentation.Configurations.MediatR.Profiles;

public static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        services.AddTransient<IRequest<ContactMessage?>, CreateContactMessageCommand>();
        services.AddTransient<IRequestHandler<CreateContactMessageCommand, ContactMessage?>, CreateContactMessageCommandHandler>();

        services.AddTransient<IRequest<Unit>, UpdateContactMessageCommand>();
        services.AddTransient<IRequestHandler<UpdateContactMessageCommand, Unit>, UpdateContactMessageCommandHandler>();

        services.AddTransient<IRequest<Unit>, DeleteContactMessageCommand>();
        services.AddTransient<IRequestHandler<DeleteContactMessageCommand, Unit>, DeleteContactMessageCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<IEnumerable<ContactMessage>>, GetContactMessageListQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageListQuery, IEnumerable<ContactMessage>>, GetContactMessageListQueryHandler>();

        services.AddScoped<IRequest<ContactMessage?>, GetContactMessageByIdQuery>();
        services.AddScoped<IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>, GetContactMessageByIdQueryHandler>();

        #endregion
    }
}