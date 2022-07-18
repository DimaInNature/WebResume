namespace WebResume.Domain.Models;

public class PetProject
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ProjectUrl { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;
}