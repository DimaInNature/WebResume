﻿namespace WR.Microservices.UserService.Domain.Queries.Users;

public sealed record class GetUserByPredicateQueryHandler
    : IRequestHandler<GetUserByPredicateQuery, UserEntity?>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public GetUserByPredicateQueryHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<UserEntity?> Handle(
        GetUserByPredicateQuery request,
        CancellationToken token)
    {
        if(request.Predicate is null) return null;
        
        return await _repository.GetFirstOrDefaultWithIncludeAsync(
            predicate: user => request.Predicate(user),
            token, 
            includeProperties: prop => prop.UserRole);
    }
}