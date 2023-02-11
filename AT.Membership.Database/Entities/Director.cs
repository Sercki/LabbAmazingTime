﻿namespace AT.Membership.Database.Entities;

public class Director : IEntity
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string? Name { get; set; }

    public virtual ICollection<Director>? Directors { get;set; }
}