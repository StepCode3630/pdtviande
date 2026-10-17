using System;

namespace backend.models;

public class recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string[] Ingredients { get; set; } = Array.Empty<string>();
    public string[] Instructions { get; set; } = Array.Empty<string>();
    public string? ImageUrl { get; set; } = string.Empty;
}
