namespace IFC.Domain.Entities;

public class District
{
    public District()
    {
        Addresses = new HashSet<Address>();
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsActive { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
}
