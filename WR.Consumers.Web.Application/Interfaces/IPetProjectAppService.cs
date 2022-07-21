namespace WR.Consumers.Web.Application.Interfaces;

public interface IPetProjectAppService
{
    Task<IEnumerable<PetProject>> GetAllAsync();

    Task<PetProject?> GetAsync(Guid key);
}