namespace WR.Microservices.UserService.Domain.Queries.UserRoles;

public sealed record class GetUserRolesListQueryHandler
    : IRequestHandler<GetUserRolesListQuery, IEnumerable<UserRoleEntity>>
{
    private readonly IGenericRepository<UserRoleEntity> _repository;

    public GetUserRolesListQueryHandler(
        IGenericRepository<UserRoleEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<UserRoleEntity>> Handle(
        GetUserRolesListQuery request,
        CancellationToken token) => 
        _repository.GetAll();
}