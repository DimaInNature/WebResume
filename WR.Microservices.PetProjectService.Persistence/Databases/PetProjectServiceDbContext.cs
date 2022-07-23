namespace WR.Microservices.PetProjectService.Persistence.Databases;

public class PetProjectServiceDbContext : DbContext
{
    public DbSet<PetProjectEntity> ContactMessages => Set<PetProjectEntity>();

    public PetProjectServiceDbContext(DbContextOptions<PetProjectServiceDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetProjectEntity>()
            .HasIndex(indexExpression: petProject => petProject.Id)
            .IsUnique();

        modelBuilder.Entity<PetProjectEntity>()
            .HasData(data: GetPetProjects());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);

    private List<PetProjectEntity> GetPetProjects() => new()
    {
        new()
        {
            Id = 1,
            RepositoryName = "Readme",
            Description = "Simple readme.md",
            CodeLines = 100,
            CreatedDate = DateTime.Now,
            WatchersCount = 5,
            ApiUrl = "https://github.com/DimaInNature/DimaInNature",
            Language = "Markdown",
            Topics = new(),
            FullRepositoryName = "https://github.com/DimaInNature/DimaInNature",
            Url = "https://github.com/DimaInNature/DimaInNature",
            StarsCount = 5,
            SubscribersCount = 5,
            UpdatedDate = DateTime.Now
        }
    };
}