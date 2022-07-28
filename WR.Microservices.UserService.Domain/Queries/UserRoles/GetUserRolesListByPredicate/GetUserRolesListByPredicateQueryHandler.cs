namespace WR.Microservices.UserService.Domain.Queries.UserRoles;

public sealed record class GetUserRolesListByPredicateQueryHandler
    : IRequestHandler<GetUserRolesListByPredicateQuery, IEnumerable<UserRoleEntity>>
{
    private readonly IGenericRepository<UserRoleEntity> _repository;

    public GetUserRolesListByPredicateQueryHandler(
        IGenericRepository<UserRoleEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<UserRoleEntity>> Handle(
        GetUserRolesListByPredicateQuery request,
        CancellationToken token)
    {
        if (request.Predicate is null) return new List<UserRoleEntity>();

        return _repository.GetAll(predicate: userRole => request.Predicate(userRole));
    }
}