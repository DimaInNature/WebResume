namespace WR.Microservices.ContactMessageService.Application.Services;

public class ContactMessageAppService : IContactMessageAppService
{
    private readonly IMediator _mediator;

    public ContactMessageAppService(IMediator mediator) => _mediator = mediator;

    public Task<IEnumerable<ContactMessageEntity>> GetAllAsync() =>
        _mediator.Send(request: new GetContactMessagesListQuery());

    public Task<ContactMessageEntity?> GetAsync(Guid key) => 
        _mediator.Send(request: new GetContactMessageByIdQuery(key));

    public Task CreateAsync(ContactMessageEntity entity) =>
        _mediator.Send(request: new CreateContactMessageCommand(entity));

    public Task UpdateAsync(ContactMessageEntity entity) =>
        _mediator.Send(request: new UpdateContactMessageCommand(entity));

    public Task DeleteAsync(Guid key) =>
        _mediator.Send(request: new DeleteContactMessageCommand(key));
}