namespace Presentation.DTOs;

using Domain.ValueObjects;
public class EnclosureDto
{
    public EnclosureType Type { get; set; } = new EnclosureType("");
    public int Size { get; set; }
    public int Capacity { get; set; }
    
}