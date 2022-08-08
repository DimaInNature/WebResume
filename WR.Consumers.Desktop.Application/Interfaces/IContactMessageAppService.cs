namespace WR.Consumers.Desktop.Application.Interfaces;

public interface IContactMessageAppService
{
    Task<IEnumerable<ContactMessage>> GetAllAsync();

    Task<ContactMessage?> GetAsync(Guid id);

    Task CreateAsync(ContactMessage entity);

    Task UpdateAsync(ContactMessage entity);

    Task DeleteAsync(Guid id);
}