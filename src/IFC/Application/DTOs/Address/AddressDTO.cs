namespace IFC.Application.DTOs.Address;

public class AddressDTO
{
    public long Id { get; set; }
    public string? Streat { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual string? City { get; set; }
    public virtual string? District { get; set; }
}
