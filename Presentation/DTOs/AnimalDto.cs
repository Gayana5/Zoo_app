namespace Presentation.DTOs;

using Domain.ValueObjects;
public class AnimalDto
{
    public Species Species { get; set; } = null!;
    public string Name { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string FavoriteFood { get; set; } = "";
}

