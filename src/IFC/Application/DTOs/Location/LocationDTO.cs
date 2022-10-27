namespace IFC.Application.DTOs.Location;

public class LocationDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }
}
