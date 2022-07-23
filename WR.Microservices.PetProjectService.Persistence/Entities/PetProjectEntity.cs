namespace WR.Microservices.PetProjectService.Persistence.Entities;

public class PetProjectEntity
{
    public int Id { get; set; }

    public string RepositoryName { get; set; } = string.Empty;

    public string FullRepositoryName { get; set; } = string.Empty;

    public string ApiUrl { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int CodeLines { get; set; }

    public int StarsCount { get; set; }

    public string Language { get; set; } = string.Empty;

    public List<string> Topics { get; set; } = new();

    public int WatchersCount { get; set; }

    public int SubscribersCount { get; set; }
}