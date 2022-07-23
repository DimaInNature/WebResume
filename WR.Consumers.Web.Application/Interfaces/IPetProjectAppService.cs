namespace WR.Consumers.Web.Application.Interfaces;

public interface IPetProjectAppService
{
    Task<IEnumerable<PetProject>> GetAllAsync(string ownerName);

    Task<PetProject?> GetAsync(string repositoryName, string ownerName);
}