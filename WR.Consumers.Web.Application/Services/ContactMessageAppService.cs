namespace WR.Consumers.Web.Application.Services;

public sealed class ContactMessageAppService : IContactMessageAppService
{
    private readonly IMediator _mediator;

    public ContactMessageAppService(IMediator mediator) => _mediator = mediator;

    public async Task<IEnumerable<ContactMessage>> GetAllAsync() =>
        await _mediator.Send(request: new GetContactMessageListQuery());

    public async Task<ContactMessage?> GetAsync(Guid id) =>
        await _mediator.Send(request: new GetContactMessageByIdQuery(id));

    public async Task CreateAsync(ContactMessage entity) =>
        await _mediator.Send(request: new CreateContactMessageCommand(entity));

    public async Task UpdateAsync(ContactMessage entity) =>
        await _mediator.Send(request: new UpdateContactMessageCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteContactMessageCommand(id));
}