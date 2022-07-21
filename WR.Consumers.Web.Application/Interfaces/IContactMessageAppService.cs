namespace WR.Consumers.Web.Application.Interfaces;

public interface IContactMessageAppService
{
    Task<IEnumerable<ContactMessage>> GetAllAsync();

    Task<ContactMessage?> GetAsync(Guid key);

    Task CreateAsync(ContactMessage entity);

    Task UpdateAsync(ContactMessage entity);

    Task DeleteAsync(Guid key);
}