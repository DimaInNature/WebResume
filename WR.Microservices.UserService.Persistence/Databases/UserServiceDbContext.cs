﻿namespace WR.Microservices.UserService.Persistence.Databases;

public sealed class UserServiceDbContext : DbContext
{
    public DbSet<UserEntity> Users => Set<UserEntity>();

    public DbSet<UserRoleEntity> UserRoles => Set<UserRoleEntity>();

    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>()
            .HasIndex(indexExpression: user => user.Id)
            .IsUnique();
 
        modelBuilder.Entity<UserEntity>()
            .HasData(data: GetUsers());

        modelBuilder.Entity<UserRoleEntity>()
            .HasIndex(indexExpression: userRole => userRole.Id)
            .IsUnique();

        modelBuilder.Entity<UserRoleEntity>()
            .HasData(data: GetUserRoles());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<UserEntity> GetUsers() => new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Username = "Admin",
            Password = "123456",
            UserRoleId = GetUserRoles().First().Id
        }
    };

    private List<UserRoleEntity> GetUserRoles() => new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Admin"
        }
    };
}