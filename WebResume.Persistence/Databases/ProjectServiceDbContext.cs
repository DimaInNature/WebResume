namespace WebResume.Persistence.Databases;

public class ProjectServiceDbContext : DbContext
{
    public DbSet<PetProjectEntity> ContactMessages => Set<PetProjectEntity>();

    public ProjectServiceDbContext(DbContextOptions<ProjectServiceDbContext> options)
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
            Id = Guid.NewGuid(),
            Name = "Readme",
            Description = "My Readme.md in GitHub",
            ProjectUrl = "https://github.com/DimaInNature/DimaInNature",
            ImageUrl = "https://avatars.githubusercontent.com/u/78268612"
        }
    };
}