namespace WR.Microservices.PetProjectService.Application.Interfaces;

public interface IPetProjectAppService
{
    Task<IEnumerable<PetProjectEntity>> GetAllAsync();

    Task<PetProjectEntity?> GetAsync(Guid key);
}