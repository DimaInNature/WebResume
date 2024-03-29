﻿namespace WR.Microservices.ContactMessageService.Persistence.Databases;

public sealed class ContactMessageServiceDbContext : DbContext
{
    public DbSet<ContactMessageEntity> ContactMessages => Set<ContactMessageEntity>();

    public ContactMessageServiceDbContext(DbContextOptions<ContactMessageServiceDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactMessageEntity>()
            .HasIndex(indexExpression: contactMessage => contactMessage.Id)
            .IsUnique();

        modelBuilder.Entity<ContactMessageEntity>()
            .HasData(data: GetContactMessages());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<ContactMessageEntity> GetContactMessages() => new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            SenderEmail = "Example@bk.com",
            SenderName = "John Snow",
            Message = "Hello Mail Service!"
        }
    };
}