namespace WR.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class PetProjectRoutesSettingsModel
{
    public string GetPetProjectListByOwnerNameRoute { get; set; } = string.Empty;

    public string GetPetProjectListByOwnerName(string ownerName) =>
        string.Format(format: GetPetProjectListByOwnerNameRoute, arg0: ownerName);
}