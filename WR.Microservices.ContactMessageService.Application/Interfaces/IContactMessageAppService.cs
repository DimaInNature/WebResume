namespace WR.Microservices.ContactMessageService.Application.Interfaces;

public interface IContactMessageAppService
{
    Task<IEnumerable<ContactMessageEntity>> GetAllAsync();

    Task<ContactMessageEntity?> GetAsync(Guid key);

    Task CreateAsync(ContactMessageEntity entity);

    Task UpdateAsync(ContactMessageEntity entity);

    Task DeleteAsync(Guid key);
}