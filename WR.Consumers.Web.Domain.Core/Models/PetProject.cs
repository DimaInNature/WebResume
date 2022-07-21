namespace WR.Consumers.Web.Domain.Core.Models;

public class PetProject
{
    public Guid Id { get; set; } = Guid.NewGuid();  

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ProjectUrl { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public PetProject(string name, string description, string projectUrl, string imageUrl) =>
        (Name, Description, ProjectUrl, ImageUrl) = (name, description, projectUrl, imageUrl);

    public PetProject(Guid id, string name, string description,
        string projectUrl, string imageUrl) : this(name, description, projectUrl, imageUrl) => Id = id;

    public PetProject() { }
}