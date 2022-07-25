namespace WR.Consumers.Desktop.Application.Services;

public sealed class ContactMessageAppService : IContactMessageAppService
{
    private readonly IMediator _mediator;

    public ContactMessageAppService(IMediator mediator) =>
        _mediator = mediator;

    public Task<IEnumerable<ContactMessage>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ContactMessage?> GetAsync(Guid key)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(ContactMessage entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ContactMessage entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid key)
    {
        throw new NotImplementedException();
    }
}