using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models;

public abstract class Base<TKey>(TKey id)
{
    [Key] public TKey Id { get; set; } = id;
    public DateTime? CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    public void SetUpdatedDate()
    {
        UpdatedAt = DateTime.Now;
    }
}