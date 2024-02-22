using FileBaseContext.Abstractions.Models.Entity;

namespace WebApplication2.Models;

public class User: IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public int? Age { get; set; }
}