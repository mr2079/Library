using System.ComponentModel.DataAnnotations;

namespace Library.WebAPI.Abstractions;

public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}