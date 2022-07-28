namespace WR.Microservices.UserService.Domain.Queries.UserRoles;

public sealed record class GetUserRoleByPredicateQueryHandler
    : IRequestHandler<GetUserRoleByPredicateQuery, UserRoleEntity?>
{
    private readonly IGenericRepository<UserRoleEntity> _repository;

    public GetUserRoleByPredicateQueryHandler(
        IGenericRepository<UserRoleEntity> repository) =>
        _repository = repository;

    public async Task<UserRoleEntity?> Handle(
        GetUserRoleByPredicateQuery request,
        CancellationToken token)
    {
        if (request.Predicate is null) return null;

        return _repository.GetFirstOrDefault(
            predicate: userRole => request.Predicate(userRole));
    }
}