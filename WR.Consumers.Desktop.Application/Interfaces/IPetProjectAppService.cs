namespace WR.Consumers.Desktop.Application.Interfaces;

public interface IPetProjectAppService
{
    Task<IEnumerable<PetProject>> GetAllByOwnerNameAsync(string ownerName);

    Task<PetProject?> GetAsync(string repositoryName, string ownerName);
}