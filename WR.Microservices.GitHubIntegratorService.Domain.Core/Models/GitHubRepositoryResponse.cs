namespace WR.Microservices.GitHubIntegratorService.Domain.Core.Models;

public sealed record class GitHubRepositoryResponse
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "name")]
    public string RepositoryName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "full_name")]
    public string FullRepositoryName { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "html_url")]
    public string ApiUrl { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "created_at")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty(PropertyName = "updated_at")]
    public DateTime UpdatedDate { get; set; }

    [JsonProperty(PropertyName = "size")]
    public int CodeLines { get; set; } 

    [JsonProperty(PropertyName = "stargazers_count")]
    public int StarsCount { get; set; }

    [JsonProperty(PropertyName = "language")]
    public string Language { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "topics")]
    public List<string> Topics { get; set; } = new();

    [JsonProperty(PropertyName = "watchers")]
    public int WatchersCount { get; set; }

    [JsonProperty(PropertyName = "subscribers_count")]
    public int SubscribersCount { get; set; }
}