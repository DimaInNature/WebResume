namespace WR.Microservices.PetProjectService.Application.Interfaces;

public interface IPetProjectAppService
{
    Task<IEnumerable<PetProjectEntity>> GetAllByOwnerNameAsync(string ownerName);

    Task<PetProjectEntity?> GetAsync(string repositoryName, string ownerName);
}