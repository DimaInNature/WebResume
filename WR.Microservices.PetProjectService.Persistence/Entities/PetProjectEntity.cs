﻿namespace WR.Microservices.PetProjectService.Persistence.Entities;

public class PetProjectEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ProjectUrl { get; set; }

    public string ImageUrl { get; set; }
}